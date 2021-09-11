using System;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class TitleEffectManager : MonoBehaviour
    {
        private TMP_Text textMesh;
        private Mesh mesh;

        [SerializeField] private float a;
        [SerializeField] private float b;
        [SerializeField] private float c;

        private Vector3[] vertices;
        private void Start()
        {
            textMesh = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            textMesh.ForceMeshUpdate();
            mesh = textMesh.mesh;
            vertices = mesh.vertices;

            for (int i = 0; i < textMesh.textInfo.characterCount; i++)
            {
                TMP_CharacterInfo c = textMesh.textInfo.characterInfo[i];

                int index = c.vertexIndex;
                
                Vector3 offset = Wobble(Time.time + i);

                vertices[index] += a * offset;
                vertices[index + 1] += a *offset;
                vertices[index + 2] += a *offset;
                vertices[index + 3] += a *offset;
            }

            mesh.vertices = vertices;
            
        }

        Vector2 Wobble(float time)
        {
            return new Vector2(Mathf.Sin(time * b), Mathf.Cos(time * c));
        }
    }
}