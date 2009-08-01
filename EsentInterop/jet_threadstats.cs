﻿//-----------------------------------------------------------------------
// <copyright file="jet_threadstats.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Vista
{
    /// <summary>
    /// Contains cumulative statistics on the work performed by the database
    /// engine on the current thread. This information is returned via
    /// <see cref="VistaApi.JetGetThreadStats"/>.
    /// </summary>
    public struct JET_THREADSTATS
    {
        /// <summary>
        /// Gets the total number of database pages visited by the database
        /// engine on the current thread.
        /// </summary>
        public int cPageReferenced { get; internal set; }

        /// <summary>
        /// Gets the total number of database pages fetched from disk by the
        /// database engine on the current thread.
        /// </summary>
        public int cPageRead { get; internal set; }

        /// <summary>
        /// Gets the total number of database pages prefetched from disk by
        /// the database engine on the current thread.
        /// </summary>
        public int cPagePreread { get; internal set; }

        /// <summary>
        /// Gets the total number of database pages, with no unwritten changes,
        /// that have been modified by the database engine on the current thread.
        /// </summary>
        public int cPageDirtied { get; internal set; }

        /// <summary>
        /// Gets the total number of database pages, with unwritten changes, that
        /// have been modified by the database engine on the current thread.
        /// </summary>
        public int cPageRedirtied { get; internal set; }

        /// <summary>
        /// Gets the total number of transaction log records that have been
        /// generated by the database engine on the current thread.
        /// </summary>
        public int cLogRecord { get; internal set; }

        /// <summary>
        /// Gets the total size in bytes of transaction log records that
        /// have been generated by the database engine on the current thread.
        /// </summary>
        public int cbLogRecord { get; internal set; }

        /// <summary>
        /// Add the stats in two JET_THREADSTATS structures.
        /// </summary>
        /// <param name="t1">The first JET_THREADSTATS.</param>
        /// <param name="t2">The second JET_THREADSTATS.</param>
        /// <returns>A JET_THREADSTATS containing the result of adding the stats in t1 and t2.</returns>
        public static JET_THREADSTATS operator +(JET_THREADSTATS t1, JET_THREADSTATS t2)
        {
            return new JET_THREADSTATS
            {
                cPageReferenced = t1.cPageReferenced + t2.cPageReferenced,
                cPageRead = t1.cPageRead + t2.cPageRead,
                cPagePreread = t1.cPagePreread + t2.cPagePreread,
                cPageDirtied = t1.cPageDirtied + t2.cPageDirtied,
                cPageRedirtied = t1.cPageRedirtied + t2.cPageRedirtied,
                cLogRecord = t1.cLogRecord + t2.cLogRecord,
                cbLogRecord = t1.cbLogRecord + t2.cbLogRecord,
            };
        }

        /// <summary>
        /// Calculate the differeence in stats between two JET_THREADSTATS structures.
        /// </summary>
        /// <param name="t1">The first JET_THREADSTATS.</param>
        /// <param name="t2">The second JET_THREADSTATS.</param>
        /// <returns>A JET_THREADSTATS containing the difference in stats between t1 and t2.</returns>
        public static JET_THREADSTATS operator -(JET_THREADSTATS t1, JET_THREADSTATS t2)
        {
            return new JET_THREADSTATS
            {
                cPageReferenced = t1.cPageReferenced - t2.cPageReferenced,
                cPageRead = t1.cPageRead - t2.cPageRead,
                cPagePreread = t1.cPagePreread - t2.cPagePreread,
                cPageDirtied = t1.cPageDirtied - t2.cPageDirtied,
                cPageRedirtied = t1.cPageRedirtied - t2.cPageRedirtied,
                cLogRecord = t1.cLogRecord - t2.cLogRecord,
                cbLogRecord = t1.cbLogRecord - t2.cbLogRecord,
            };
        }

        /// <summary>
        /// Sets the fields of the object from a NATIVE_THREADSTATS struct.
        /// </summary>
        /// <param name="value">
        /// The native threadstats to set the values from.
        /// </param>
        internal void SetFromNativeThreadstats(NATIVE_THREADSTATS value)
        {
            this.cPageReferenced = checked((int) value.cPageReferenced);
            this.cPageRead = checked((int) value.cPageRead);
            this.cPagePreread = checked((int) value.cPagePreread);
            this.cPageDirtied = checked((int) value.cPageDirtied);
            this.cPageRedirtied = checked((int) value.cPageRedirtied);
            this.cLogRecord = checked((int) value.cLogRecord);
            this.cbLogRecord = checked((int) value.cbLogRecord);
        }
    }

    /// <summary>
    /// The native version of the JET_THREADSTATS structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NATIVE_THREADSTATS
    {
        public uint cbStruct;
        public uint cPageReferenced;
        public uint cPageRead;
        public uint cPagePreread;
        public uint cPageDirtied;
        public uint cPageRedirtied;
        public uint cLogRecord;
        public uint cbLogRecord;
    }
}