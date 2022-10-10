// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable NotAccessedField.Local

using UnityEngine;

namespace GG.Base
{
    /// <summary>
    /// Base class for ScriptableObjects that need a public description field.
    /// </summary>
    public class DescriptionBaseSO : ScriptableObject
    {
        [TextArea] [SerializeField] private string _description;
    }
}