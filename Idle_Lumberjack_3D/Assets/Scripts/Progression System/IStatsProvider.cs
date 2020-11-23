using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lumberjack.Stats
{
    public interface IStatsProvider
    {
        BaseStats stats { get; }
    }
}