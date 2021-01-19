﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.ovf.u2</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_Ovf_U2()
            => new Emit_Conv_Ovf_U2();


        private sealed class Emit_Conv_Ovf_U2 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U2;

            public Emit_Conv_Ovf_U2()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotImplementedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }
        }
    }
}
