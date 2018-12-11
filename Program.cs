using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace vmnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = InitializeBrainFuckProcessor();

            if (processor is IReportableProcessor reportable)
            {
                var report = reportable.Report();
                Console.WriteLine(report);
            }
        }

        static IProcessor InitializeBrainFuckProcessor() 
        {
            var registerNames = new
            {
                ProgramPointer = "Program Pointer",
                MemoryPointer = "Memory Pointer",
            };

            var registers = new List<IRegister>
            {
                Register.SimpleRegister(registerNames.ProgramPointer),
                Register.SimpleRegister(registerNames.MemoryPointer),
            };

            var memoryNames = new
            {
                MainMemory = "Main Memory",
            };

            var memories = new List<IMemory>
            {
                Memory.EmptyMemory(memoryNames.MainMemory),
            };

            var incrementOperation = new Operation<int>(Functional.Math.Add(1));
            var decrementOperation = new Operation<int>(Functional.Math.Subtract(1));

            var instructions = new List<IInstruction> 
            {
                Instruction.CreateInstruction(
                    "No Operation",
                    0x00,
                    new MachineOperation(Functional.Identity)
                ),
                Instruction.CreateInstruction(
                    "Increment Memory Pointer",
                    0x10,
                    new MachineOperation(state => state
                        .UpdateRegisterValue(registerNames.MemoryPointer, incrementOperation))
                ),
                Instruction.CreateInstruction(
                    "Decrement Memory Pointer",
                    0x11,
                    new MachineOperation(state => state
                        .UpdateRegisterValue(registerNames.MemoryPointer, decrementOperation))
                ),
                Instruction.CreateInstruction(
                    "Dereference And Increment Memory Value",
                    0x20,
                    new MachineOperation(state => {
                        var memoryAddress = state.GetRegisterValue(registerNames.MemoryPointer);
                        return state.UpdateMemoryValue(
                            memoryNames.MainMemory,
                            memoryAddress,
                            incrementOperation);
                    })
                )
            };

            var processor = Processor.CreateEmpty("BrainFuck Processor")
                .AddRegisters(registers)
                .AddMemories(memories)
                .AddInstructions(instructions);

            return processor;
        }
    }
}
