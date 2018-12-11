using System;

namespace vmnet 
{
    public class Instruction
        : IInstruction
    {
        public string Name { get => _name; }
        private string _name { get; set; }

        public int Code { get => _code; }
        private int _code { get; set; }

        public IOperation<IMachineState> Operation { get => _operation; }
        private IOperation<IMachineState> _operation { get; set; }

        private Instruction(
            string name,
            int code,
            IOperation<IMachineState> operation) =>
            this
                .Tee(() => _name = name)
                .Tee(() => _code = code)
                .Tee(() => _operation = operation);

        public static IInstruction CreateInstruction(
            string name,
            int code,
            IOperation<IMachineState> operation) =>
            new Instruction(name, code, operation);
    }
}
