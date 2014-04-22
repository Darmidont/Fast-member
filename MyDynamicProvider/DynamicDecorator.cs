using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDynamicProvider
{
    public class DynamicDecorator<TComponentInterface> : DynamicObject
    {
        /// <summary>Component - defines an object to which additional
        /// responsibilities can be attached.</summary>
        protected TComponentInterface _component;

        /// <summary>Represents component type.</summary>
        private Type _componentType;

        /// <summary>Initializes a new instance of the
        /// <see cref="DynamicDecorator&lt;TComponentInterface&gt;"/> class.</summary>
        /// <param name="component">The component to which additional
        /// responsibilities can be attached.</param>
        public DynamicDecorator(TComponentInterface component)
        {
            this.Component = component;
        }

        /// <summary>Gets or sets the object to which 
        /// additional responsibilities can be attached.</summary>
        public TComponentInterface Component
        {
            get { return this._component; }
            set
            {
                this._component = value;
                this._componentType = this._component.GetType();
            }
        }

        /// <summary>Provides the implementation for operations that set member values.</summary>
        /// <param name="binder">Provides information about the object
        /// that called the dynamic operation.</param>
        /// <param name="value">The value to set to the member.</param>
        /// <returns>true if the operation is successful; otherwise, false.</returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            // search for a property
            PropertyInfo property = this._componentType.GetProperty(binder.Name,
                BindingFlags.Public | BindingFlags.Instance);
            if (property != null)
            {
                property.SetValue(this._component, value, null);
                return true;
            }

            // search for a public field
            FieldInfo field = this._componentType.GetField(binder.Name,
                BindingFlags.Public | BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(this._component, value);
                return true;
            }

            return base.TrySetMember(binder, value);
        }

        /// <summary>Gets the list of arguments types.</summary>
        /// <param name="args">An object array that contains arguments.</param>
        /// <returns>The list of arguments types.</returns>
        private Type[] GetArgumentsTypes(object[] args)
        {
            Type[] argTypes = new Type[args.GetLength(0)];

            int index = 0;
            foreach (var arg in args)
            {
                argTypes[index] = arg.GetType();
                index++;
            }

            return argTypes;
        }

        /// <summary>Provides the implementation for operations that invoke a member.</summary>
        /// <param name="binder">Provides information about the dynamic operation.</param>
        /// <param name="args">The arguments that are passed to the object member
        /// during the invoke operation.</param>
        /// <param name="result">The result of the member invocation.</param>
        /// <returns>true if the operation is successful; otherwise, false.</returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args,
            out object result)
        {
            MethodInfo method = this._componentType.GetMethod(binder.Name,
                BindingFlags.Public | BindingFlags.Instance, null, this.GetArgumentsTypes(args), null);

            if (method != null)
            {
                result = method.Invoke(this._component, args);
                return true;
            }

            return base.TryInvokeMember(binder, args, out result);
        }
    }
}
