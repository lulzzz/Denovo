﻿// Autarkysoft.Bitcoin
// Copyright (c) 2020 Autarkysoft
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Runtime.CompilerServices;

namespace Autarkysoft.Bitcoin.Blockchain.Scripts.Operations
{
    /// <summary>
    /// Does nothing (but affects how hash for signatures are produced).
    /// </summary>
    public class CodeSeparatorOp : BaseOperation
    {
        /// <inheritdoc cref="IOperation.OpValue"/>
        public override OP OpValue => OP.CodeSeparator;

        /// <summary>
        /// Indicates whether this operation was executed or not.
        /// </summary>
        public bool IsExecuted = false;

        /// <summary>
        /// Does nothing. 
        /// <para/> Under the hood, it changes the <see cref="IsExecuted"/> value to false which would affect how
        /// the script containing this operation is going to be serialized for signing.
        /// </summary>
        /// <param name="opData">Data to use</param>
        /// <param name="error">Always null</param>
        /// <returns>Always true</returns>
        public override bool Run(IOpData opData, out string error)
        {
            IsExecuted = true;
            error = null;
            return true;
        }

        /// <summary>
        /// Writes nothing to stream since <see cref="OP.CodeSeparator"/>s are not included in scripts while signing.
        /// </summary>
        /// <param name="stream">Stream to use</param>
        /// <param name="sig"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteToStreamForSigning(FastStream stream, ReadOnlySpan<byte> sig)
        {
        }
    }
}
