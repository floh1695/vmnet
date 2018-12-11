using System;

namespace vmnet
{
    public interface IMachineState
    {
        IRegister GetRegister(string registerName);
        IMachineState UpdateRegister(string registerName, IOperation<IRegister> operation);
        IMachineState UpdateMemory(string memoryName, IOperation<IMemory> operation);
    }
}