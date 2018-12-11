using System;

namespace vmnet 
{
    public interface IProcessor
        : HasName
    {
        IProcessor AddRegister(IRegister register);
        IProcessor AddMemory(IMemory memory);
        IProcessor AddInstruction(IInstruction instruction);
    }
}