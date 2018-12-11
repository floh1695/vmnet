using System;
using System.Collections;
using System.Collections.Generic;

namespace vmnet
{
    public class Processor
        : IProcessor, IReportableProcessor
    {
        public string Name { get => _name; }
        private string _name { get; set; }

        public ICollection<IRegister> Registers { get => _registers; }
        private ICollection<IRegister> _registers { get; set; }

        public ICollection<IInstruction> Instructions { get => _instructions; }
        private ICollection<IInstruction> _instructions { get; set; }

        public ICollection<IMemory> Memories { get => _memories; }
        private ICollection<IMemory> _memories { get; set; }


        private Processor(string name) =>
            this
                .Tee(() => _name = name)
                .Tee(() => _registers = new List<IRegister>())
                .Tee(() => _instructions = new List<IInstruction>())
                .Tee(() => _memories = new List<IMemory>());

        private Processor(Processor processor) =>
            this
                .Tee(@this => @this._name = processor.Name)
                .Tee(@this => @this._registers = processor.Registers)
                .Tee(@this => @this._instructions = processor.Instructions)
                .Tee(@this => @this._memories = processor.Memories);


        public static IProcessor CreateEmpty(string name) =>
            new Processor(name);


        public IProcessor AddRegister(IRegister register) =>
            new Processor(this)
                .Tee(@this => @this._registers.Add(register));

        public IProcessor AddMemory(IMemory memory) =>
            new Processor(this)
                .Tee(@this => @this._memories.Add(memory));

        public IProcessor AddInstruction(IInstruction instruction) =>
            new Processor(this)
                .Tee(@this => @this._instructions.Add(instruction));
    }
}
