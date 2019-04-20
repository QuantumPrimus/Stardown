using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[RequireComponent(typeof(Rigidbody2D))]
public class Explodable : MonoBehaviour
{
    public System.Action<List<GameObject>> OnFragmentsGenerated;

    public bool allowRuntimeFragmentation = false;
    public int extraPoints = 0;
    public int subshatterSteps = 0;
    // private List<Rigidbody2D> fragRBs = new List<Rigidbody2D>();
    public string fragmentLayer = "Default";
    public string sortingLayerName = "Default";
    public int orderInLayer = 0;
    private List<keepMoving> kms = new List<keepMoving>();

    private keepMoving km;
        public enum ShatterType
    {
        Triangle,
        Voronoi
    };
    public ShatterType shatterType;
    public List<GameObject> fragments = new List<GameObject>();
    private List<List<Vector2>> polygons = new List<List<Vector2>>();

    /// <summary>
    /// Creates fragments if necessary and destroys original gameobject
    /// </summary>
    /// 


    public void explode()
    {
       
        //if fragments were not created before runtime then create them now
        if (fragments.Count == 0 && allowRuntimeFragmentation)
        {
            generateFragments();
        }
        //otherwise unparent and activate them
        else
        {
            int counter = 0;
            foreach (GameObject frag in fragments)
            {
                counter++;
                frag.transform.parent = null;
                //fadeParticles fp = frag.GetComponent<fadeParticles>();
                frag.SetActive(true);
                //Trying to get the "particles" just fade out instead of just
                //Poofing out of existence 

                // fp.fadeObject(0, 2);

                //Trying to get the "partilces" to fly off after they explode
                //They just kinda...sit there

                // fragRBs.Add(frag.GetComponent<Rigidbody2D>());
                //kms[counter].done();
                frag.GetComponent<keepMoving>().done();
                frag.GetComponent<fadeParticles>().fadeObject(0, 1f);
                // Renderer ren = frag.GetComponent<Renderer>();
                // ren.material.color = new Color(ren.material.color.r, ren.material.color.b, ren.material.color.g, .5f);
                // Debug.Log(frag);
            }

            
        }
        //if fragments exist destroy the original
        if (fragments.Count > 0)
        {
            Destroy(gameObject);
        }
        
    }
    /// <summary>
    /// Creates fragments and then disables them
    /// </summary>
    public void fragmentInEditor()
    {
        if (fragments.Count > 0)
        {
            deleteFragments();
        }
        generateFragments();
        setPolygonsForDrawing();
        foreach (GameObject frag in fragments)
        {
            frag.transform.parent = transform;
            frag.SetActive(false);
        }
    }
    public void deleteFragments()
    {
        foreach (GameObject frag in fragments)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(frag);
            }
            else
            {
                Destroy(frag);
            }
        }
        fragments.Clear();
        polygons.Clear();
    }
    /// <summary>
    /// Turns Gameobject into multiple fragments
    /// </summary>
    public void generateFragments()
    {
        fragments = new List<GameObject>();
        switch (shatterType)
        {
            case ShatterType.Triangle:
                fragments = SpriteExploder.GenerateTriangularPieces(gameObject, extraPoints, subshatterSteps);
                break;
            case ShatterType.Voronoi:
                fragments = SpriteExploder.GenerateVoronoiPieces(gameObject, extraPoints, subshatterSteps);
                break;
            default:
                Debug.Log("invalid choice");
                break;
        }
        //sets additional aspects of the fragments
        foreach (GameObject p in fragments)
        {
            if (p != null)
            {
                p.layer = LayerMask.NameToLayer(fragmentLayer);
                p.AddComponent<fadeParticles>();
                p.GetComponent<Renderer>().sortingLayerName = sortingLayerName;
                p.GetComponent<Renderer>().sortingOrder = orderInLayer;
                p.GetComponent<Rigidbody2D>().gravityScale = 0;
                p.AddComponent<keepMoving>();
                // km = p.GetComponent<keepMoving>();
                // kms.Add(km);
                // km.create(p.GetComponent<Rigidbody2D>());
                // p.AddComponent<SelfDestruct>();

                // p.GetComponent<SelfDestruct>().lifeSpan = 2f;
            }
        }

        foreach (ExplodableAddon addon in GetComponents<ExplodableAddon>())
        {
            if (addon.enabled)
            {
                addon.OnFragmentsGenerated(fragments);
            }
        }
    }
    private void setPolygonsForDrawing()
    {
        polygons.Clear();
        List<Vector2> polygon;

        foreach (GameObject frag in fragments)
        {
            polygon = new List<Vector2>();
            foreach (Vector2 point in frag.GetComponent<PolygonCollider2D>().points)
            {
                Vector2 offset = rotateAroundPivot((Vector2)frag.transform.position, (Vector2)transform.position, Quaternion.Inverse(transform.rotation)) - (Vector2)transform.position;
                offset.x /= transform.localScale.x;
                offset.y /= transform.localScale.y;
                polygon.Add(point + offset);
            }
            polygons.Add(polygon);
        }
    }
    private Vector2 rotateAroundPivot(Vector2 point, Vector2 pivot, Quaternion angle)
    {
        Vector2 dir = point - pivot;
        dir = angle * dir;
        point = dir + pivot;
        return point;
    }

    void OnDrawGizmos()
    {
        if (Application.isEditor)
        {
            if (polygons.Count == 0 && fragments.Count != 0)
            {
                setPolygonsForDrawing();
            }

            Gizmos.color = Color.blue;
            Gizmos.matrix = transform.localToWorldMatrix;
            Vector2 offset = (Vector2)transform.position * 0;
            foreach (List<Vector2> polygon in polygons)
            {
                for (int i = 0; i < polygon.Count; i++)
                {
                    if (i + 1 == polygon.Count)
                    {
                        Gizmos.DrawLine(polygon[i] + offset, polygon[0] + offset);
                    }
                    else
                    {
                        Gizmos.DrawLine(polygon[i] + offset, polygon[i + 1] + offset);
                    }
                }
            }
        }
    }
}
