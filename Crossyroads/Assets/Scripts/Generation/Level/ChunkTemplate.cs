using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LaneGen;
namespace Chunk
{
    
[CreateAssetMenu(menuName ="Crossy/Chunk/NewChunk")]
public class ChunkTemplate : ScriptableObject
{
    public List<Lane> lanes;
}
}
