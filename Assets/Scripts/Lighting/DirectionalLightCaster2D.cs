using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightCaster2D : MonoBehaviour
{
    public GameObject[] sceneObjects;

    public LayerMask obstacleLayer;

    public bool isLightOn = true;

    public Transform startPoint;
    public Transform endPoint;

    [Min(0.0001f)]
    public float length;
    [Range(0, 360)]
    public float angle;

    public int orderinLayer;
    public string sortingLayer;
    public float offset = 0.01f;

    public GameObject lightRays;

    private Mesh mesh;

    public struct AngledLines
    {
        public Vector3 rootVert;
        public Vector2 rootuv;
        public Vector3 vert;
        public Vector2 uv;
    }

    void Start()
    {

        mesh = lightRays.GetComponent<MeshFilter>().mesh;
        lightRays.GetComponent<MeshRenderer>().sortingOrder = orderinLayer;
        lightRays.GetComponent<MeshRenderer>().sortingLayerName = sortingLayer;

    }

    public static int[] AddItemsToArray(int[] original, int itemToAdd1, int itemToAdd2, int itemToAdd3)
    {
        int[] finalArray = new int[original.Length + 3];
        for (int i = 0; i < original.Length; i++)
        {
            finalArray[i] = original[i];
        }
        finalArray[original.Length] = itemToAdd1;
        finalArray[original.Length + 1] = itemToAdd2;
        finalArray[original.Length + 2] = itemToAdd3;
        return finalArray;
    }

    public static Vector3[] ConcatArrays(Vector3[] first, Vector3[] second)
    {
        Vector3[] concatted = new Vector3[first.Length + second.Length];

        System.Array.Copy(first, concatted, first.Length);
        System.Array.Copy(second, 0, concatted, first.Length, second.Length);

        return concatted;
    }

    void Update()
    {
        if (!isLightOn)
        {
            lightRays.SetActive(false);
            return;
        }

        lightRays.SetActive(true);

        mesh.Clear();
        Vector3[] objverts = new Vector3[0];
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            objverts = ConcatArrays(objverts, sceneObjects[i].GetComponent<MeshFilter>().mesh.vertices);
        }

        AngledLines[] angledLines = new AngledLines[(objverts.Length * 2) + 2];

        float lineDistance = Vector2.Distance(startPoint.position, endPoint.position);
        Vector3 angleDir = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0).normalized;
        Vector3 lineDir = (endPoint.position - startPoint.position).normalized;

        int h = 1;

        RaycastHit startHit;
        bool sh = Physics.Raycast(startPoint.position, angleDir, out startHit, length, obstacleLayer);
        if (sh)
        {
            angledLines[0].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(startHit.point);
            angledLines[0].uv = CalculateUV(startHit.point, angleDir, lineDir, lineDistance);
        }
        else
        {
            angledLines[0].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(startPoint.position + angleDir * length);
            angledLines[0].uv = new Vector2(0, 1);
        }
        angledLines[0].rootVert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(startPoint.position);
        angledLines[0].rootuv = new Vector2(0, 0);


        RaycastHit endHit;
        bool eh = Physics.Raycast(endPoint.position, angleDir, out endHit, length, obstacleLayer);
        if (eh)
        {
            angledLines[1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(endHit.point);
            angledLines[1].uv = CalculateUV(endHit.point, angleDir, lineDir, lineDistance);
            Debug.Log(angledLines[1].uv);
        }
        else
        {
            angledLines[1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(endPoint.position + angleDir * length);
            angledLines[1].uv = new Vector2(1, 1);
        }
        angledLines[1].rootVert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(endPoint.position);
        angledLines[1].rootuv = new Vector2(1, 0);

        for (int i = 0; i < sceneObjects.Length; i++)
        {
            Vector3[] mesh = sceneObjects[i].GetComponent<MeshFilter>().mesh.vertices;
            for (int j = 0; j < mesh.Length; j++)
            {
                Vector3 vertLoc = sceneObjects[i].transform.localToWorldMatrix.MultiplyPoint3x4(mesh[j]);
                vertLoc = new Vector3(vertLoc.x, vertLoc.y, 0);
                RaycastHit hit, hit2;

                Vector3 hitPoint1 = vertLoc + lineDir * offset;
                Vector3 hitPoint2 = vertLoc - lineDir * offset;

                if (IsInArea(hitPoint1, angleDir, lineDir, lineDistance))
                {
                    Vector3 p1 = HitLine(hitPoint1, hitPoint1 - angleDir * length, angleDir);
                    bool b1 = Physics.Raycast(p1, angleDir, out hit, length, obstacleLayer);
                    if (b1)
                    {
                        angledLines[(h * 2)].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(hit.point);
                        angledLines[(h * 2)].uv = CalculateUV(hit.point, angleDir, lineDir, lineDistance);
                    }
                    else
                    {
                        Vector3 bp = HitBoundary(hitPoint1, hitPoint1 + angleDir * length, angleDir);
                        angledLines[(h * 2)].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(bp);
                        angledLines[(h * 2)].uv = CalculateUV(bp, angleDir, lineDir, lineDistance);
                    }
                    angledLines[(h * 2)].rootVert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(p1);
                    angledLines[(h * 2)].rootuv = CalculateUV(p1, angleDir, lineDir, lineDistance);
                }
                else
                {
                    angledLines[(h * 2)].vert = Vector3.zero;
                    angledLines[(h * 2)].uv = new Vector2(1000, 1000);
                    angledLines[(h * 2)].rootVert = Vector3.zero;
                    angledLines[(h * 2)].rootuv = new Vector2(1000, 1000);
                }

                if (IsInArea(hitPoint2, angleDir, lineDir, lineDistance))
                {
                    Vector3 p2 = HitLine(hitPoint2, hitPoint2 - angleDir * length, angleDir);
                    bool b2 = Physics.Raycast(p2, angleDir, out hit2, length, obstacleLayer);
                    if (b2)
                    {
                        angledLines[(h * 2) + 1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(hit2.point);
                        angledLines[(h * 2) + 1].uv = CalculateUV(hit2.point, angleDir, lineDir, lineDistance);
                    }
                    else
                    {
                        Vector3 bp = HitBoundary(hitPoint2, hitPoint2 + angleDir * length, angleDir);
                        angledLines[(h * 2) + 1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(bp);
                        angledLines[(h * 2) + 1].uv = CalculateUV(bp, angleDir, lineDir, lineDistance);
                    }
                    angledLines[(h * 2) + 1].rootVert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(p2);
                    angledLines[(h * 2) + 1].rootuv = CalculateUV(p2, angleDir, lineDir, lineDistance);
                }
                else
                {

                    angledLines[(h * 2) + 1].vert = Vector3.zero;
                    angledLines[(h * 2) + 1].uv = new Vector2(1000, 1000);
                    angledLines[(h * 2) + 1].rootVert = Vector3.zero;
                    angledLines[(h * 2) + 1].rootuv = new Vector2(1000, 1000);
                }

                h++;
            }
        }

        System.Array.Sort(angledLines, delegate (AngledLines one, AngledLines two) {
            return (one.rootuv.x).CompareTo(two.rootuv.x);
        });

        Vector3[] verts = new Vector3[(objverts.Length * 4) + 4];
        Vector2[] uvs = new Vector2[(objverts.Length * 4) + 4];
        Vector3[] normals = new Vector3[(objverts.Length * 4) + 4];

        int flag = 0;
        for (int i = 0; i < angledLines.Length; i++)
        {
            verts[i * 2] = angledLines[i].rootVert;
            uvs[i * 2] = angledLines[i].rootuv;
            verts[i * 2 + 1] = angledLines[i].vert;
            uvs[i * 2 + 1] = angledLines[i].uv;
            if (flag == 0 && angledLines[i].rootuv.x > 100.0f)
            {
                flag = i * 2;
            }
        }

        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = new Vector3(0, 0, -1);
        }

        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.normals = normals;

        int[] triangles = new int[0];
        for (int i = flag == 0 ? verts.Length - 1 : flag - 1; i > 1; i -= 2)
        {
            triangles = AddItemsToArray(triangles, i - 1, i, i - 3);
            triangles = AddItemsToArray(triangles, i, i - 2, i - 3);
        }
        mesh.triangles = triangles;
    }

    public Vector2 CalculateUV(Vector3 point, Vector3 lightDir, Vector3 lineDir, float lineDis)
    {
        Vector3 pointVector = point - startPoint.position;
        Vector3 dx = lineDir * lineDis;
        Vector3 dy = lightDir * length;
        if (lightDir == lineDir)
        {
            return Vector2.zero;
        }
        float x = 0, y = 0;
        if (dx.x == 0)
        {
            y = pointVector.x / dy.x;
            x = (pointVector.y - dy.y * y) / dx.y;
        }
        else if (dx.y == 0)
        {
            y = pointVector.y / dy.y;
            x = (pointVector.x - dy.x * y) / dx.x;
        }
        else
        {
            y = (dx.y * pointVector.x - dx.x * pointVector.y) / (dx.y * dy.x - dy.y * dx.x);
            x = (pointVector.y - dy.y * y) / dx.y;
        }
        return new Vector2(x, y);
    }

    public bool IsInArea(Vector3 point, Vector3 lightDir, Vector3 lineDir, float lineDis)
    {
        Vector3 pointVector = point - startPoint.position;
        Vector3 dx = lineDir * lineDis;
        Vector3 dy = lightDir * length;
        if (lightDir == lineDir)
        {
            return false;
        }
        float x = 0, y = 0;
        if (dx.x == 0)
        {
            y = pointVector.x / dy.x;
            x = (pointVector.y - dy.y * y) / dx.y;
        }
        else if (dx.y == 0)
        {
            y = pointVector.y / dy.y;
            x = (pointVector.x - dy.x * y) / dx.x;
        }
        else
        {
            y = (dx.y * pointVector.x - dx.x * pointVector.y) / (dx.y * dy.x - dy.y * dx.x);
            x = (pointVector.y - dy.y * y) / dx.y;
        }

        if (x < 0 || y < 0 || x > 1.0f || y > 1.0f)
        {
            return false;
        }
        return true;
    }

    public Vector3 HitBoundary(Vector3 start, Vector3 end, Vector3 lightDir)
    {
        Vector2 intersection = Vector2.zero;
        if (LineIntersection(start, end, startPoint.position + lightDir * length, endPoint.position + lightDir * length, ref intersection))
        {
            return intersection;
        }
        return Vector2.zero;
    }


    public Vector3 HitLine(Vector3 start, Vector3 end, Vector3 lightDir)
    {
        Vector2 intersection = Vector2.zero;
        if (LineIntersection(start, end, startPoint.position, endPoint.position, ref intersection))
        {
            return intersection;
        }
        return Vector2.zero;
    }

    public static bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 intersection)
    {

        float Ax, Bx, Cx, Ay, By, Cy, d, e, f, num/*,offset*/;
        float x1lo, x1hi, y1lo, y1hi;

        Ax = p2.x - p1.x;
        Bx = p3.x - p4.x;

        // X bound box test/
        if (Ax < 0)
        {
            x1lo = p2.x; x1hi = p1.x;
        }
        else
        {
            x1hi = p2.x; x1lo = p1.x;
        }

        if (Bx > 0)
        {
            if (x1hi < p4.x || p3.x < x1lo) return false;
        }
        else
        {
            if (x1hi < p3.x || p4.x < x1lo) return false;
        }

        Ay = p2.y - p1.y;
        By = p3.y - p4.y;

        // Y bound box test//
        if (Ay < 0)
        {
            y1lo = p2.y; y1hi = p1.y;
        }
        else
        {
            y1hi = p2.y; y1lo = p1.y;
        }

        if (By > 0)
        {
            if (y1hi < p4.y || p3.y < y1lo) return false;
        }
        else
        {
            if (y1hi < p3.y || p4.y < y1lo) return false;
        }

        Cx = p1.x - p3.x;
        Cy = p1.y - p3.y;
        d = By * Cx - Bx * Cy;  // alpha numerator//
        f = Ay * Bx - Ax * By;  // both denominator//

        // alpha tests//
        if (f > 0)
        {
            if (d < 0 || d > f) return false;
        }
        else
        {
            if (d > 0 || d < f) return false;
        }

        e = Ax * Cy - Ay * Cx;  // beta numerator//

        // beta tests //
        if (f > 0)
        {
            if (e < 0 || e > f) return false;
        }
        else
        {
            if (e > 0 || e < f) return false;
        }

        // check if they are parallel
        if (f == 0) return false;

        // compute intersection coordinates //
        num = d * Ax; // numerator //

        //    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;   // round direction //

        //    intersection.x = p1.x + (num+offset) / f;
        intersection.x = p1.x + num / f;

        num = d * Ay;
        //    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;

        //    intersection.y = p1.y + (num+offset) / f;
        intersection.y = p1.y + num / f;

        return true;

    }

    public void Bake()
    {
        mesh = lightRays.GetComponent<MeshFilter>().sharedMesh;
        lightRays.GetComponent<MeshRenderer>().sortingOrder = orderinLayer;
        lightRays.GetComponent<MeshRenderer>().sortingLayerName = sortingLayer;
        Update();
    }
}
