using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class NutsController : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private GameObject spinner;
    private List<GameObject> nutsForSpawn;
    private List<int> spawnChanses;

    private List<GameObject> redBolt;
    private List<GameObject> blueBolt;
    private List<GameObject> greenBolt;
    private List<GameObject> yellowBolt;

    private List<List<GameObject>> colorBolts;

    private GameObject currentNut;
    private float nutSpeed;
    private bool isBlockedSended;
    private float blockRotatePosition;
    private int indexCurrentBolt;
    private float correctPosition;

    private void Awake()
    {
        EventManager.OnBoltChanged.AddListener(SetCurrentBolt);
        EventManager.OnTimeOut.AddListener(StartMoveNut);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ClearSpinner();
        }
    }


    public void Start()
    {
        redBolt = new List<GameObject>();
        blueBolt = new List<GameObject>();
        greenBolt = new List<GameObject>();
        yellowBolt = new List<GameObject>();
        colorBolts = new List<List<GameObject>>();
        colorBolts.Add(redBolt);
        colorBolts.Add(blueBolt);
        colorBolts.Add(greenBolt);
        colorBolts.Add(yellowBolt);

        correctPosition = settings.correctPosition;
        blockRotatePosition = settings.blockRotatePosition;
        spawnChanses = settings.chanses;
        nutsForSpawn = settings.nutsForSpawn;
        nutSpeed = settings.nutSpeed;
        Invoke("NutSpawn", 1);

    }

    public void NutSpawn()
    {
        currentNut = Instantiate(nutsForSpawn[NutSpawnIndex()], settings.nutSpawnPoint, Quaternion.identity);
        EventManager.SendNutSpawned();
    }
    void AddNutToList(int boltIndex, GameObject nut)
    {
        colorBolts[boltIndex].Add(nut);
        EventManager.SendNutDelivered();
        isBlockedSended = false;
    }

    void RemoveNutFromList(List<GameObject> bolt, int index)
    {
        bolt.RemoveAt(index);
    }
    private int SumChance()
    {
        int sum = 0;
        for (int i = 0; i < spawnChanses.Count; i++)
        {
            sum += spawnChanses[i];
        }
        return sum;
    }

    int NutSpawnIndex()
    {
        int a = 0;
        int i = 0;
        int rand = Random.Range(1, SumChance());
        while (a < rand)
        {
            a += spawnChanses[i];
            i++;
        }
        return i - 1;
    }

    private void SetCurrentBolt(int index)
    {
        indexCurrentBolt = index;
    }

    IEnumerator MoveNut()
    {
        while (currentNut.transform.position.y > colorBolts[indexCurrentBolt].Count + correctPosition)
        {
            currentNut.transform.Translate(Vector3.down * Time.deltaTime * nutSpeed);
            if (currentNut.transform.position.y < blockRotatePosition && !isBlockedSended)
            {
                isBlockedSended = true;
                EventManager.SendBlockSpinner();
            }
            yield return null;
        }
        SetParentObject();
        AddNutToList(indexCurrentBolt, currentNut);
        CheckBolt();
        NutSpawn();
    }

    private void SetParentObject()
    {
        currentNut.transform.SetParent(spinner.transform);
    }

    private void StartMoveNut()
    {
        StartCoroutine(MoveNut());
    }

    private void CheckBolt()
    {
        if (colorBolts[indexCurrentBolt].Count < 3)
        {
            return;
        }
        else
        {
            CheckColors();
        }
    }
    private void CheckColors()
    {
        List<GameObject> bolt = colorBolts[indexCurrentBolt];
        if (currentNut.tag == "rust")
        {
            return;
        }
        if (currentNut.tag == "acid")
        {
            //AcidNutMethod
        }
        if (currentNut.tag == "rainbow" && bolt[bolt.Count - 2].tag == bolt[bolt.Count - 3].tag ||
            currentNut.tag == "rainbow" && bolt[bolt.Count - 3].tag == "rainbow" ||
            currentNut.tag == "rainbow" && bolt[bolt.Count - 2].tag == "rainbow")
        {
            RemoveThree(bolt);
            return;
        }
        if (currentNut.tag == bolt[bolt.Count - 2].tag && bolt[bolt.Count - 2].tag == bolt[bolt.Count - 3].tag ||
            currentNut.tag == bolt[bolt.Count - 2].tag && bolt[bolt.Count - 3].tag == "rainbow" ||
            currentNut.tag == bolt[bolt.Count - 3].tag && bolt[bolt.Count - 2].tag == "rainbow" ||
            bolt[bolt.Count - 2].tag == "rainbow" && bolt[bolt.Count - 3].tag == "rainbow")
        {
            RemoveThree(bolt);
            return;
        }
        if(bolt.Count > 5)
        {
            EventManager.SendGameOver();
        }
    }
    private void RemoveThree(List<GameObject> bolt)
    {
        int a = bolt.Count - 1;
        for (int i = 0; i < 3; i++)
        {
            Destroy(bolt[a]);
            bolt.RemoveAt(a);
            a--;
        }
    }

    private void ClearSpinner()
    {
        List<NutWithPosition> objects = new List<NutWithPosition>();

        int b = 0;
        for (int i = 0; i < colorBolts.Count; i++)
        {
            for (int j = 0; j < colorBolts[i].Count; j++)
            {
                NutWithPosition nut = new NutWithPosition(colorBolts[i][j], i, j);
                objects.Add(nut);
            }
        }
        var results = objects.OrderBy(u => u.nut.tag).ToList();

        for (int k = 0; k < results.Count - 2;)
        {
            if (results[k].nut.tag == results[k + 1].nut.tag && results[k + 1].nut.tag == results[k + 2].nut.tag)
            {
                for (int i = 3; i > 0; i--)
                {
                    results.RemoveAt(k + i - 1);
                }
            }
            else
            {
                k++;
            }
        }


        for (int i = 0; i < colorBolts.Count; i++)
        {
            for (int k = colorBolts[i].Count; k > 0; k--)
            {
                Destroy(colorBolts[i][k - 1]);
                colorBolts[i].RemoveAt(k - 1);
            }

        }
        var startSpinnerRotation = spinner.transform.eulerAngles.z;
        var tempCurrentIndex = indexCurrentBolt;
        for (int i = 0; i < results.Count; i++)
        {
            var tempObj = Instantiate(results[i].nut, new Vector3(0, colorBolts[indexCurrentBolt].Count + correctPosition + 1, 0), Quaternion.identity);
            colorBolts[indexCurrentBolt].Add(tempObj);
            tempObj.transform.SetParent(spinner.transform);
            var degr = spinner.transform.eulerAngles.z;
            spinner.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degr - 90));


            if (indexCurrentBolt == 0)
            {
                indexCurrentBolt = 3;
            }
            else
            {
                indexCurrentBolt--;
            }
        }
        spinner.transform.rotation = Quaternion.Euler(new Vector3(0, 0, startSpinnerRotation));
        indexCurrentBolt = tempCurrentIndex;
    }
}
class NutWithPosition
{
    public GameObject nut;
    public int currentBolt;
    public int currentIndex;

    public NutWithPosition(GameObject nut, int currentBolt, int currentIndex)
    {
        this.nut = nut;
        this.currentBolt = currentBolt;
        this.currentIndex = currentIndex;
    }
}
