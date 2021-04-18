using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightCaster2D : MonoBehaviour
{
    public GameObject[] sceneObjects;

    public LayerMask obstacleLayer;

    public bool isLightOn = true;

    [Min(0.0001f)]
    public float size;
    [Range(-180, 180)]
    public float startAngle;
    [Range(0, 360)]
    public float angle;

    public int orderinLayer;
    public string sortingLayer;
    public float offset = 0.01f;

    public GameObject lightRays;

    private Mesh mesh;

    private float startAngle1;
    private float endAngle1;
    private float startAngle2;
    private float endAngle2;

    public struct AngledVerts
    {
        public Vector3 vert;
        public float angle;
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

        AngledVerts[] angledVerts = new AngledVerts[(objverts.Length * 2) + 6];

        startAngle1 = startAngle;
        if (startAngle + angle <= 180.0f)
        {
            endAngle1 = startAngle + angle;
            startAngle2 = -10000.0f;
            endAngle2 = -10000.0f;
        }
        else
        {
            endAngle1 = 180.0f;
            startAngle2 = -180.0f;
            endAngle2 = startAngle + angle - 360.0f;
        }

        int h = 3;

        Vector3 myLoc = lightRays.transform.position;
        if ((45.0f >= startAngle1 && 45.0f <= endAngle1) || (45.0f >= startAngle2 && 45.0f <= endAngle2))
        {

            RaycastHit rightUphit;
            bool rub = Physics.Raycast(myLoc, new Vector3(size, size, 0), out rightUphit, size, obstacleLayer);
            if (rub)
            {
                angledVerts[0].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(rightUphit.point);
            }
            else
            {
                angledVerts[0].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(myLoc + new Vector3(size, size, 0));
            }
            angledVerts[0].angle = Mathf.Atan2(size, size);
            angledVerts[0].uv = new Vector2(angledVerts[0].vert.x, angledVerts[0].vert.y);
        }
        else
        {
            angledVerts[0].vert = Vector3.zero;
            angledVerts[0].angle = 1000.0f;
            angledVerts[0].uv = new Vector2(angledVerts[0].vert.x, angledVerts[0].vert.y);
        }

        if ((135.0f >= startAngle1 && 135.0f <= endAngle1) || (135.0f >= startAngle2 && 135.0f <= endAngle2))
        {
            RaycastHit leftUphit;
            bool lub = Physics.Raycast(myLoc, new Vector3(-size, size, 0), out leftUphit, size, obstacleLayer);
            if (lub)
            {
                angledVerts[1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(leftUphit.point);
            }
            else
            {
                angledVerts[1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(myLoc + new Vector3(-size, size, 0));
            }
            angledVerts[1].angle = Mathf.Atan2(size, -size);
            angledVerts[1].uv = new Vector2(angledVerts[1].vert.x, angledVerts[1].vert.y);
        }
        else
        {
            angledVerts[1].vert = Vector3.zero;
            angledVerts[1].angle = 1000.0f;
            angledVerts[1].uv = new Vector2(angledVerts[1].vert.x, angledVerts[1].vert.y);
        }

        if ((-45.0f >= startAngle1 && -45.0f <= endAngle1) || (-45.0f >= startAngle2 && -45.0f <= endAngle2))
        {

            RaycastHit rightDownhit;
            bool rdb = Physics.Raycast(myLoc, new Vector3(size, -size, 0), out rightDownhit, size, obstacleLayer);
            if (rdb)
            {
                angledVerts[2].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(rightDownhit.point);
            }
            else
            {
                angledVerts[2].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(myLoc + new Vector3(size, -size, 0));
            }
            angledVerts[2].angle = Mathf.Atan2(-size, size);
            angledVerts[2].uv = new Vector2(angledVerts[2].vert.x, angledVerts[2].vert.y);
        }
        else
        {
            angledVerts[2].vert = Vector3.zero;
            angledVerts[2].angle = 1000.0f;
            angledVerts[2].uv = new Vector2(angledVerts[2].vert.x, angledVerts[2].vert.y);
        }

        if ((-135.0f >= startAngle1 && -135.0f <= endAngle1) || (-135.0f >= startAngle2 && -135.0f <= endAngle2))
        {
            RaycastHit leftDownhit;
            bool ldb = Physics.Raycast(myLoc, new Vector3(-size, -size, 0), out leftDownhit, size, obstacleLayer);
            if (ldb)
            {
                angledVerts[3].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(leftDownhit.point);
            }
            else
            {
                angledVerts[3].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(myLoc + new Vector3(-size, -size, 0));
            }
            angledVerts[3].angle = Mathf.Atan2(-size, -size);
            angledVerts[3].uv = new Vector2(angledVerts[3].vert.x, angledVerts[3].vert.y);
        }
        else
        {
            angledVerts[3].vert = Vector3.zero;
            angledVerts[3].angle = 1000.0f;
            angledVerts[3].uv = new Vector2(angledVerts[3].vert.x, angledVerts[3].vert.y);
        }

        RaycastHit angle1Hit;
        Vector3 angle1Dir = new Vector3(Mathf.Cos(Mathf.Deg2Rad * startAngle1), Mathf.Sin(Mathf.Deg2Rad * startAngle1), 0);
        bool a1h = Physics.Raycast(myLoc, angle1Dir, out angle1Hit, size, obstacleLayer);
        if (a1h)
        {
            angledVerts[4].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(angle1Hit.point);
        }
        else
        {
            angledVerts[4].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(HitBoundary(myLoc, myLoc + angle1Dir * size * 2, startAngle1));
        }
        angledVerts[4].angle = -50.0f;
        angledVerts[4].uv = new Vector2(angledVerts[4].vert.x, angledVerts[4].vert.y);


        RaycastHit angle2Hit;
        Vector3 angle2Dir = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (endAngle2 >= -180 ? endAngle2 : endAngle1)), Mathf.Sin(Mathf.Deg2Rad * (endAngle2 >= -180 ? endAngle2 : endAngle1)), 0);
        bool a2h = Physics.Raycast(myLoc, angle2Dir, out angle2Hit, size, obstacleLayer);
        if (a2h)
        {
            angledVerts[5].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(angle2Hit.point);
        }
        else
        {
            angledVerts[5].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(HitBoundary(myLoc, myLoc + angle2Dir * size * 2, (endAngle2 >= -180 ? endAngle2 : endAngle1)));
        }
        angledVerts[5].angle = 50.0f;
        angledVerts[5].uv = new Vector2(angledVerts[5].vert.x, angledVerts[5].vert.y);

        for (int i = 0; i < sceneObjects.Length; i++)
        {
            Vector3[] mesh = sceneObjects[i].GetComponent<MeshFilter>().mesh.vertices;
            for (int j = 0; j < mesh.Length; j++)
            {
                Vector3 vertLoc = sceneObjects[i].transform.localToWorldMatrix.MultiplyPoint3x4(mesh[j]);
                RaycastHit hit, hit2;

                float angle1 = Mathf.Atan2((vertLoc.y - myLoc.y - offset), (vertLoc.x - myLoc.x - offset));
                float angle2 = Mathf.Atan2((vertLoc.y - myLoc.y + offset), (vertLoc.x - myLoc.x + offset));

                if ((angle1 * Mathf.Rad2Deg >= startAngle1 && angle1 * Mathf.Rad2Deg <= endAngle1) || (angle1 * Mathf.Rad2Deg >= startAngle2 && angle1 * Mathf.Rad2Deg <= endAngle2))
                {

                    bool b1 = Physics.Raycast(myLoc, new Vector2(vertLoc.x - myLoc.x - offset, vertLoc.y - myLoc.y - offset), out hit, size, obstacleLayer);
                    if (b1)
                    {
                        angledVerts[(h * 2)].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(hit.point);
                    }
                    else
                    {
                        angledVerts[(h * 2)].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(HitBoundary(myLoc, myLoc + (new Vector3(vertLoc.x - myLoc.x - offset, vertLoc.y - myLoc.y - offset)).normalized * size * 2, angle1 * Mathf.Rad2Deg));
                    }
                    angledVerts[(h * 2)].angle = angle1;
                    angledVerts[(h * 2)].uv = new Vector2(angledVerts[(h * 2)].vert.x, angledVerts[(h * 2)].vert.y);
                }
                else
                {
                    angledVerts[(h * 2)].vert = Vector3.zero;
                    angledVerts[(h * 2)].angle = 1000.0f;
                    angledVerts[(h * 2)].uv = new Vector2(angledVerts[(h * 2)].vert.x, angledVerts[(h * 2)].vert.y);
                }

                if ((angle2 * Mathf.Rad2Deg >= startAngle1 && angle2 * Mathf.Rad2Deg <= endAngle1) || (angle2 * Mathf.Rad2Deg >= startAngle2 && angle2 * Mathf.Rad2Deg <= endAngle2))
                {

                    bool b2 = Physics.Raycast(myLoc, new Vector2(vertLoc.x - myLoc.x + offset, vertLoc.y - myLoc.y + offset), out hit2, size, obstacleLayer);

                    if (b2)
                    {
                        angledVerts[(h * 2) + 1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(hit2.point);
                    }
                    else
                    {
                        angledVerts[(h * 2) + 1].vert = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(HitBoundary(myLoc, myLoc + (new Vector3(vertLoc.x - myLoc.x + offset, vertLoc.y - myLoc.y + offset)).normalized * size * 2, angle2 * Mathf.Rad2Deg));
                    }
                    angledVerts[(h * 2) + 1].angle = angle2;
                    angledVerts[(h * 2) + 1].uv = new Vector2(angledVerts[(h * 2) + 1].vert.x, angledVerts[(h * 2) + 1].vert.y);
                }
                else
                {
                    angledVerts[(h * 2) + 1].vert = Vector3.zero;
                    angledVerts[(h * 2) + 1].angle = 1000.0f;
                    angledVerts[(h * 2) + 1].uv = new Vector2(angledVerts[(h * 2) + 1].vert.x, angledVerts[(h * 2) + 1].vert.y);
                }

                h++;

            }
        }

        for (int i = 0; i < angledVerts.Length; i++)
        {
            if (angledVerts[i].angle < 0)
            {
                angledVerts[i].angle += 360.0f * Mathf.Deg2Rad;
            }
            angledVerts[i].angle -= (startAngle1 < 0 ? startAngle1 + 360.0f : startAngle1) * Mathf.Deg2Rad;
            if (angledVerts[i].angle < 0)
            {
                angledVerts[i].angle += 360.0f * Mathf.Deg2Rad;
            }
        }

        System.Array.Sort(angledVerts, delegate (AngledVerts one, AngledVerts two) {
            return one.angle.CompareTo(two.angle);
        });

        Vector3[] verts = new Vector3[(objverts.Length * 2) + 1 + 6];
        Vector2[] uvs = new Vector2[(objverts.Length * 2) + 1 + 6];

        verts[0] = lightRays.transform.worldToLocalMatrix.MultiplyPoint3x4(this.transform.position);
        uvs[0] = new Vector2(verts[0].x, verts[0].y);
        int flag = 0;
        for (int i = 0; i < angledVerts.Length; i++)
        {
            verts[i + 1] = angledVerts[i].vert;
            uvs[i + 1] = angledVerts[i].uv;
            if (flag == 0 && angledVerts[i].angle > 100.0f)
            {
                flag = i;
            }
        }

        mesh.vertices = verts;

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(uvs[i].x / size + .5f, uvs[i].y / size + .5f);
        }

        mesh.uv = uvs;

        int[] triangles = new int[0];
        for (int i = flag == 0 ? verts.Length - 1 : flag; i > 0; i--)
        {
            triangles = AddItemsToArray(triangles, 0, i, i - 1);
        }
        mesh.triangles = triangles;
    }

    public Vector3 HitBoundary(Vector3 start, Vector3 end, float angle)
    {
        if ((angle >= 0 && angle <= 45) || (angle <= 0 && angle >= -45))
        {
            Vector2 intersection = Vector2.zero;
            if (LineIntersection(start, end, new Vector2(lightRays.transform.position.x + size, lightRays.transform.position.y + size), new Vector2(lightRays.transform.position.x + size, lightRays.transform.position.y - size), ref intersection))
            {
                return intersection;
            }
        }
        if ((angle >= -180 && angle <= -135) || (angle <= 180 && angle >= 135))
        {
            Vector2 intersection = Vector2.zero;
            if (LineIntersection(start, end, new Vector2(lightRays.transform.position.x - size, lightRays.transform.position.y + size), new Vector2(lightRays.transform.position.x - size, lightRays.transform.position.y - size), ref intersection))
            {
                return intersection;
            }
        }
        if (angle >= 45 && angle <= 135)
        {
            Vector2 intersection = Vector2.zero;
            if (LineIntersection(start, end, new Vector2(lightRays.transform.position.x + size, lightRays.transform.position.y + size), new Vector2(lightRays.transform.position.x - size, lightRays.transform.position.y + size), ref intersection))
            {
                return intersection;
            }
        }
        if (angle >= -135 && angle <= -45)
        {
            Vector2 intersection = Vector2.zero;
            if (LineIntersection(start, end, new Vector2(lightRays.transform.position.x + size, lightRays.transform.position.y - size), new Vector2(lightRays.transform.position.x - size, lightRays.transform.position.y - size), ref intersection))
            {
                return intersection;
            }
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
