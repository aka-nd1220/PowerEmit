﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.ovf.u2.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_Ovf_U2_Un()
            => new Emit_Conv_Ovf_U2_Un();


        private sealed class Emit_Conv_Ovf_U2_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U2_Un;

            public Emit_Conv_Ovf_U2_Un()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                StackType resultType = type switch
                {
                    StackType.Int32 or
                    StackType.Int64 or
                    StackType.NativeInt or
                    StackType.F => StackType.Int32.Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                checked
                {
                    var value = state.EvaluationStack.Pop();
                    var resultValue = value switch
                    {
                        StackValue.Int32       x => StackValue.FromValue((ushort)unchecked((uint) x.Value)),
                        StackValue.Int64       x => StackValue.FromValue((ushort)unchecked((ulong)x.Value)),
                        StackValue.NativeInt   x => StackValue.FromValue((ushort)unchecked((nuint)x.Value)),
                        StackValue.F x => StackValue.FromValue((ushort)Math.Abs(Math.Truncate(x.Value))),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
