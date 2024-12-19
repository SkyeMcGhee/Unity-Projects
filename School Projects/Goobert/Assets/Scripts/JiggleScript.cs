using UnityEngine;
using UnityEngine.Rendering;

public class JiggleScript : MonoBehaviour
{
    public Renderer renderer;
    public Mesh mesh;
    public MeshFilter meshFilter;
    public float fallForce;
    public float speed;
    public float stiffness;

    JellyVert[] jellyVerts;
    Vector3[] currentVerts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
       
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.sharedMesh;


        GetVertices();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateVert();
    }

    public void GetVertices()
    {
        jellyVerts = new JellyVert[mesh.vertices.Length];
        currentVerts = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < jellyVerts.Length; i++)
        {
            jellyVerts[i] = new JellyVert(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentVerts[i] = mesh.vertices[i];
        }
    }

    public void UpdateVert()
    {
        for (int i = 0; i < jellyVerts.Length; i++)
        {
            jellyVerts[i].UpdateVelocity(speed);
            jellyVerts[i].Settle(stiffness);

            jellyVerts[i].curPos += jellyVerts[i].curvelocity * Time.deltaTime;
            currentVerts[i] = jellyVerts[i].curPos;
        }

        mesh.vertices = currentVerts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    public void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            Vector3 inputPoint = contactPoints[i].point + (contactPoints[i].point * 0.1f);
            ApplyPressureToPoint(inputPoint, fallForce);


        }
    }

    public void ApplyPressureToPoint(Vector3 inputPoint, float pressure)
    {
        for(int i = 0; i < jellyVerts.Length; i++)
        {
            jellyVerts[i].ApplyPressure(transform, inputPoint, pressure);
        }
    }

}

public class JellyVert
{
    public int vertIndex;
    public Vector3 initPos;
    public Vector3 curPos;
    public Vector3 curvelocity;

    public JellyVert(int vertIndex, Vector3 initPos, Vector3 curPos, Vector3 velocity)
    {
        this.vertIndex = vertIndex;
        this.initPos = initPos;
        this.curPos = curPos;
        this.curvelocity = velocity;
    }

    public Vector3 GetDisplace() 
    { 
        return curPos - initPos;
    }

    public void UpdateVelocity(float _speed)
    {
        curvelocity = curvelocity - GetDisplace() * _speed * Time.deltaTime;
    }

    public void Settle(float _stiffness)
    {
        curvelocity *= 1f - _stiffness * Time.deltaTime;
    }

    public void ApplyPressure(Transform transform, Vector3 pos, float pressure)
    {
        Vector3 distanceVert = curPos - transform.InverseTransformPoint(pos);
        float adaptPress = pressure / (1f + distanceVert.sqrMagnitude);
        float velocity = adaptPress * Time.deltaTime;
        curvelocity += distanceVert.normalized * velocity;
    }

  
}
