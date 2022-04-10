using System.Collections;
using System.Collections.Generic;
using LaneGen;
using UnityEngine;

namespace Chunk
{
    [CreateAssetMenu(menuName = "Crossy/Chunk/New chunk")]
    public class ChunkTemplate : ScriptableObject
    {
        public List<Lane> lanes;
    }
}
