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
    private List<GameObject> forAcid;

    private GameObject currentNut;
    private GameObject moveParticle;
    private GameObject finishParticle;
    private GameObject moveTempParticle;
    private GameObject destroyParticle;
    private GameObject acidParticle;
    private GameObject rainbowParticle;
    private GameObject stoneNut;
    private JewelsController jewelsController;
    private float nutSpeed;
    private float rotateNutSpeed;
    private bool isBlockedSended;
    private float blockRotatePosition;
    private int indexCurrentBolt;
    private float correctPosition;
    private int manaPoints;
    private GameObject tempParticle;

    private void Awake()
    {
        EventManager.OnBoltChanged.AddListener(SetCurrentBolt);
        EventManager.OnTimeOut.AddListener(StartMoveNut);
        EventManager.OnClearBoltButtonClicked.AddListener(ClearBolt);
        EventManager.OnClearSpinnerButtonClicked.AddListener(ClearSpinner);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ClearSpinner();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ClearBolt();
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

        manaPoints = settings.manaPoints;
        jewelsController = settings.jewelsController;
        acidParticle = settings.acidParticle;
        finishParticle = settings.finishParticle;
        moveParticle = settings.moveParticle;
        destroyParticle = settings.destroyParticle;
        rotateNutSpeed = settings.rotateNutSpeed;
        rainbowParticle = settings.rainbowParticle;
        stoneNut = settings.stoneNut;
        correctPosition = settings.correctPosition;
        blockRotatePosition = settings.blockRotatePosition;
        spawnChanses = settings.chanses;
        nutsForSpawn = settings.nutsForSpawn;
        nutSpeed = settings.nutSpeed;
        forAcid = settings.forAcid;
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
                
                if(currentNut.tag != "acid")
                {
                    StartCoroutine(RotateNut());
                    PlayMoveParticle(moveParticle, currentNut);
                }
                EventManager.SendBlockSpinner();
            }
            yield return null;
        }
        currentNut.transform.position = new Vector3(0, colorBolts[indexCurrentBolt].Count + correctPosition, 0);
        currentNut.transform.rotation = Quaternion.identity;
        Destroy(moveTempParticle);
        if (currentNut.tag != "acid")
        {
            var finParticle = Instantiate(finishParticle, new Vector3(0, currentNut.transform.position.y, -2), Quaternion.identity);
            DeleteAfterPlay(finParticle, 0.5f);
        }
        else
        {
            var acidPart = Instantiate(acidParticle, new Vector3(0, currentNut.transform.position.y, -2), Quaternion.identity);
            DeleteAfterPlay(acidPart, 1.2f);
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
        if (colorBolts[indexCurrentBolt].Count < 3 && currentNut.tag != "acid")
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
        if (currentNut.tag == "stone")
        {
            return;
        }
        if (currentNut.tag == "acid")
        {
            Destroy(currentNut);
            bolt.Remove(bolt.Last());
            if(bolt.Count > 0 && bolt.Last().tag == "stone")
            {
                Destroy(bolt.Last());
                bolt.Remove(bolt.Last());
                var nut = Instantiate(forAcid[indexCurrentBolt], new Vector3(0, bolt.Count + correctPosition, 0), Quaternion.identity);
                nut.transform.SetParent(spinner.transform);
                bolt.Add(nut);
                currentNut = nut;
            }
            if(bolt.Count < 3)
            {
                return;
            }
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
        var boltTag = forAcid[indexCurrentBolt].tag;
        if (bolt[bolt.Count-1].tag == boltTag || bolt[bolt.Count - 2].tag == boltTag || bolt[bolt.Count - 3].tag == boltTag)
        {
            EventManager.SendTrueBoltColor(manaPoints);
        }
        else
        {
            SetStone();
        }
        string jewelTag;
        for (int i = 3; i > 0; i--)
        {
            if(bolt[bolt.Count - i].tag == "Rainbow")
            {
                continue;
            }
            else
            {
                jewelTag = bolt[bolt.Count - i].tag;
                jewelsController.AddJewels(jewelTag, 1);
            }
        }
        int a = bolt.Count - 1;
        for (int i = 0; i < 3; i++)
        {
            Destroy(bolt[a]);
            if(bolt[a].tag == "rainbow")
            {
                StartCoroutine(PlayParticle(rainbowParticle, bolt[a], 1f));
            }
            else
            {
                StartCoroutine(PlayParticle(destroyParticle, bolt[a], 1f));
            }
            bolt.RemoveAt(a);
            a--;
        }
        

    }


    private void ClearBolt()
    {
        int nutNumOfBolt = colorBolts[indexCurrentBolt].Count;
        for (int i = nutNumOfBolt - 1; i > -1 ; i--)
        {
            Destroy(colorBolts[indexCurrentBolt][i]);
            StartCoroutine(PlayParticle(destroyParticle, colorBolts[indexCurrentBolt][i], 2f));
            colorBolts[indexCurrentBolt].RemoveAt(i);
        }
    }

    private void SetStone()
    {
        var rand = Random.Range(1, 3);
        var startSpinnerRotation = spinner.transform.eulerAngles.z;
        var tempCurrentIndex = indexCurrentBolt;
        for (int i = 0; i < rand; i++)
        {
            spinner.transform.rotation = Quaternion.Euler(new Vector3(0, 0, spinner.transform.rotation.eulerAngles.z - 90));
            if (indexCurrentBolt == 0)
            {
                indexCurrentBolt = 3;
            }
            else
            {
                indexCurrentBolt--;
            }
        }

        var stone = Instantiate(stoneNut, new Vector3(0, colorBolts[indexCurrentBolt].Count + correctPosition, 0), Quaternion.identity);
        stone.transform.SetParent(spinner.transform);
        colorBolts[indexCurrentBolt].Add(stone);
        spinner.transform.rotation = Quaternion.Euler(new Vector3(0, 0, startSpinnerRotation));
        indexCurrentBolt = tempCurrentIndex;

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
            var tempObj = Instantiate(results[i].nut, new Vector3(0, colorBolts[indexCurrentBolt].Count + correctPosition, 0), Quaternion.identity);
            //tempObj.transform.localScale = new Vector3(1, 1, 1);
            tempObj.transform.SetParent(spinner.transform);
            colorBolts[indexCurrentBolt].Add(tempObj);
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

    IEnumerator RotateNut()
    {
        while (isBlockedSended)
        {
            currentNut.transform.Rotate(0, 1 * rotateNutSpeed * Time.deltaTime, 0);
            yield return null;
        }
    }

    private void PlayMoveParticle(GameObject particle, GameObject parent)
    {
        moveTempParticle = Instantiate(particle, parent.transform.position, Quaternion.identity);
        moveTempParticle.transform.SetParent(parent.transform);
    }

    IEnumerator PlayParticle(GameObject particle, GameObject parent, float playTime)
    {
        var obj = Instantiate(particle, parent.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(playTime);
        Destroy(obj);

    }

    void DeleteAfterPlay(GameObject particle, float delay)
    {
        tempParticle = particle;
        Invoke("Delete", delay);
    }

    void Delete()
    {
        Destroy(tempParticle);
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
