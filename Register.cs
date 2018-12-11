using System;

namespace vmnet
{
    public class Register
        : IRegister
    {
        public string Name { get => _name; }
        private string _name { get; set; }

        public int Value { get => _value; }
        private int _value { get; set; }

        private Register(string name) =>
            this
                .Tee(() => _name = name)
                .Tee(() => _value = default(int));

        private Register(IRegister register) =>
            this
                .Tee(() => _name = register.Name)
                .Tee(() => _value = register.Value);

        public static IRegister SimpleRegister(string name) =>
            new Register(name);

        public IRegister UpdateValue(IOperation<int> operation) =>
            new Register(this)
                .Tee(@this => @this._value = operation.Run(@this._value));
    }
}