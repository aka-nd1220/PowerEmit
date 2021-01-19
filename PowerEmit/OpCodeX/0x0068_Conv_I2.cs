﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.i2</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_I2()
            => new Emit_Conv_I2();


        private sealed class Emit_Conv_I2 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_I2;

            public Emit_Conv_I2()
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
                unchecked
                {
                    var value = state.EvaluationStack.Pop();
                    var resultValue = value switch
                    {
                        StackValue.Int32       x => StackValue.FromValue((short)x.Value),
                        StackValue.Int64       x => StackValue.FromValue((short)x.Value),
                        StackValue.NativeInt   x => StackValue.FromValue((short)x.Value),
                        StackValue.F x => StackValue.FromValue((short)x.Value),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
