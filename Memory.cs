using System;
using System.Collections;
using System.Collections.Generic;

namespace vmnet
{
    class Memory
        : IMemory
    {
        public string Name { get => _name; }
        private string _name { get; set; }

        private IList<int> _values { get; }


        private Memory(string name) =>
            this
                .Tee(() => _name = name);

        private Memory(Memory memory) =>
            this
                .Tee(() => _name = memory._name);


        public static IMemory EmptyMemory(string name) =>
            new Memory(name);
            

        public IMemory UpdateValue(int address, IOperation<int> operation) =>
            new Memory(this)
                .Tee(@this => @this._values[address] = operation.Run(@this._values[address]));
    }
}