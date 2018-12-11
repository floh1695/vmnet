using System;

namespace vmnet
{
    public static class IMachineStateExtensions
    {
        public static int GetRegisterValue(
            this IMachineState @this,
            string registerName) =>
            @this.GetRegister(registerName).Value;

        public static IMachineState UpdateRegisterValue(
            this IMachineState @this,
            string registerName,
            IOperation<int> operation) =>
            @this
                .UpdateRegister(
                    registerName,
                    new Operation<IRegister>(register => register
                        .UpdateValue(operation))
                );

        public static IMachineState UpdateMemoryValue(
            this IMachineState @this,
            string name,
            int address,
            IOperation<int> operation) =>
            @this
                .UpdateMemory(
                    name,
                    new Operation<IMemory>(memory => memory
                        .UpdateValue(address, operation))
                );
    }
}