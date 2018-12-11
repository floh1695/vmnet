using System;
using System.Collections;
using System.Collections.Generic;

namespace vmnet
{
    public interface IReportableProcessor
        : HasName
    {
        ICollection<IRegister> Registers { get; }
        ICollection<IInstruction> Instructions { get; }
        ICollection<IMemory> Memories { get; }
    }
}