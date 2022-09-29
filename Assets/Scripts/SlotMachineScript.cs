using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineScript : MonoBehaviour
{
    [Header("Slot Machine visuals")]
    [SerializeField] private Row[] rows;
    [SerializeField] private GameObject[] imageResults;

    [Header("Randomizer values")]
    string randomChar, randomPerk1, randomPerk2, randomPerk3, randomPerk4;
    private List<string> randomCharacterList = new List<string>();
    private List<string> randomPerkList = new List<string>();

    [Header("Functionality variables")]
    private bool rotating;
    private bool killer;

    [Header("Data")]
    private Data smData;

    [Header("Debugging")]
    [SerializeField] private GameObject PopupPanel;
    private string debug;



    // Start is called before the first frame update
    void Start()
    {
        rotating = false;
        smData = gameObject.GetComponent<Data>();
    }

    
    public void StartRotation(int option)
    {
        if (!rotating)
        {
            SlotMachineOn();

            CharacterRandomizer(option);

            if (killer)
            {
                KillerRandomizer();
            }

            else if (!killer)
            {
                SurvivorRandomizer();
            }

            //Starting coroutine to automatically stop rotation
            StartCoroutine("Stop");
        }
    }

    private void SlotMachineOn()
    {
        //Results disabled. Rows enabled, setting stop to false and start rotation
        for (int i = 0; i < 5; i++)
        {
            imageResults[i].gameObject.SetActive(false);

            rows[i].gameObject.SetActive(true);
            rows[i].rowStopped = false;
            rows[i].Rotation();
        }
        rotating = true;
    }

    private void CharacterRandomizer(int option)
    {
        //Setting option
        if (option == 1)
            killer = false;

        else if (option == 2)
        {
            int randomOption = Random.Range(0, 2);

            if (randomOption == 0)
                killer = true;

            else
                killer = false;
        }

        else if (option == 3)
            killer = true;
    }



    private void KillerRandomizer()
    {
        //Killer icon randomizer
        for (int i = 0; i < smData.data.Killers.Length; i++)
        {
            if (smData.data.Killers[i].active == true)
            {
                randomCharacterList.Add(smData.data.Killers[i].id);
            }
        }

        if (randomCharacterList.Count >= 1)
        {
            randomChar = randomCharacterList[Random.Range(0, randomCharacterList.Count)];

            for (int i = 0; i < smData.data.Killers.Length; i++)
            {
                if (smData.data.Killers[i].id == randomChar)
                {
                    imageResults[0].gameObject.GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>(smData.data.Killers[i].image);
                    debug = "124\nKiller Name: " + smData.data.Killers[i].name + "\nKiller Image: " + smData.data.Killers[i].image;

                    //Killer perks randomizer
                    for (int j = 0; j < smData.data.Killers[i].Perks.Length; j++)
                    {
                        if (smData.data.Killers[i].Perks[j].active == true)
                        {
                            randomPerkList.Add(smData.data.Killers[i].Perks[j].id);
                        }
                    }

                    if (randomPerkList.Count >= 1)
                    {
                        randomPerk4 = randomPerkList[Random.Range(0, randomPerkList.Count)];

                        if (randomPerkList.Count >= 1)
                        {
                            randomPerk3 = randomPerkList[Random.Range(0, randomPerkList.Count)];
                            randomPerkList.Remove(randomPerk3);

                            if (randomPerkList.Count >= 1)
                            {
                                randomPerk2 = randomPerkList[Random.Range(0, randomPerkList.Count)];
                                randomPerkList.Remove(randomPerk2);

                                if (randomPerkList.Count >= 1)
                                {
                                    randomPerk1 = randomPerkList[Random.Range(0, randomPerkList.Count)];
                                    randomPerkList.Remove(randomPerk1);
                                }

                                else
                                    SetEmptyIcon(1, 4, "Images/Killers/IconKiller_Killer");
                            }

                            else
                                SetEmptyIcon(2, 4, "Images/Killers/IconKiller_Killer");
                        }

                        else
                            SetEmptyIcon(3, 4, "Images/Killers/IconKiller_Killer");
                    }

                    else
                        SetEmptyIcon(4, 4, "Images/Killers/IconKiller_Killer");

                    for (int j = 0; j < smData.data.KillerPerks.Length; j++)
                    {
                        if (randomPerk1 != null && smData.data.KillerPerks[j].id == randomPerk1)
                        {
                            imageResults[1].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.KillerPerks[j].image);
                            debug = debug + "\n\n176\nPerk1: " + randomPerk1 + "\nName: " + smData.data.KillerPerks[j].name + "\nImage: " + smData.data.KillerPerks[j].image;
                        }

                        else if (randomPerk2 != null && smData.data.KillerPerks[j].id == randomPerk2)
                        {
                            imageResults[2].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.KillerPerks[j].image);
                            debug = debug + "\n\n183\nPerk2: " + randomPerk2 + "\nName: " + smData.data.KillerPerks[j].name + "\nImage: " + smData.data.KillerPerks[j].image;
                        }

                        else if (randomPerk3 != null && smData.data.KillerPerks[j].id == randomPerk3)
                        {
                            imageResults[3].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.KillerPerks[j].image);
                            debug = debug + "\n\n190\nPerk3: " + randomPerk3 + "\nName: " + smData.data.KillerPerks[j].name + "\nImage: " + smData.data.KillerPerks[j].image;
                        }

                        else if (randomPerk4 != null && smData.data.KillerPerks[j].id == randomPerk4)
                        {
                            imageResults[4].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.KillerPerks[j].image);
                            debug = debug + "\n\n197\nPerk4: " + randomPerk4 + "\nName: " + smData.data.KillerPerks[j].name + "\nImage: " + smData.data.KillerPerks[j].image;
                        }
                    }
                }
            }
        }

        else
        {
            SetEmptyIcon(0, 4, "Images/Killers/IconKiller_Killer");
        }

        ResetVariables();
    }


    private void SurvivorRandomizer()
    {
        //Survivor icon randomizer
        for (int i = 0; i < smData.data.Survivors.Length; i++)
        {
            if (smData.data.Survivors[i].active == true)
            {
                randomCharacterList.Add(smData.data.Survivors[i].id);
            }
        }

        if (randomCharacterList.Count >= 1)
        {

            randomChar = randomCharacterList[Random.Range(0, randomCharacterList.Count)];

            for (int i = 0; i < smData.data.Survivors.Length; i++)
            {
                if (smData.data.Survivors[i].id == randomChar)
                {
                    imageResults[0].gameObject.GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>(smData.data.Survivors[i].image);
                    debug = debug + "226\nSurvivor Name: " + smData.data.Survivors[i].name + "\nSurvivor Image: " + smData.data.Survivors[i].image;

                    //Survivor perks randomizer
                    for (int j = 0; j < smData.data.Survivors[i].Perks.Length; j++)
                    {
                        if (smData.data.Survivors[i].Perks[j].active == true)
                        {
                            randomPerkList.Add(smData.data.Survivors[i].Perks[j].id);
                        }
                    }

                    if (randomPerkList.Count >= 1)
                    {
                        randomPerk4 = randomPerkList[Random.Range(0, randomPerkList.Count)];

                        if (randomPerkList.Count >= 1)
                        {
                            randomPerk3 = randomPerkList[Random.Range(0, randomPerkList.Count)];
                            randomPerkList.Remove(randomPerk3);

                            if (randomPerkList.Count >= 1)
                            {
                                randomPerk2 = randomPerkList[Random.Range(0, randomPerkList.Count)];
                                randomPerkList.Remove(randomPerk2);

                                if (randomPerkList.Count >= 1)
                                {
                                    randomPerk1 = randomPerkList[Random.Range(0, randomPerkList.Count)];
                                    randomPerkList.Remove(randomPerk1);
                                }

                                else
                                    SetEmptyIcon(1, 4, "Images/Survivors/IconSurvivor_Survivor");
                            }

                            else
                                SetEmptyIcon(2, 4, "Images/Survivors/IconSurvivor_Survivor");
                        }

                        else
                            SetEmptyIcon(3, 4, "Images/Survivors/IconSurvivor_Survivor");
                    }

                    else
                        SetEmptyIcon(4, 4, "Images/Survivors/IconSurvivor_Survivor");

                    for (int j = 0; j < smData.data.SurvivorPerks.Length; j++)
                    {
                        if (smData.data.SurvivorPerks[j].id == randomPerk1)
                        {
                            imageResults[1].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.SurvivorPerks[j].image);
                            debug = debug + "\n\n278\nPerk1: " + randomPerk1 + "\nName: " + smData.data.SurvivorPerks[j].name + "\nImage: " + smData.data.SurvivorPerks[j].image;
                        }

                        else if (smData.data.SurvivorPerks[j].id == randomPerk2)
                        {
                            imageResults[2].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.SurvivorPerks[j].image);
                            debug = debug + "\n\n285\nPerk2: " + randomPerk2 + "\nName: " + smData.data.SurvivorPerks[j].name + "\nImage: " + smData.data.SurvivorPerks[j].image;
                        }

                        else if (smData.data.SurvivorPerks[j].id == randomPerk3)
                        {
                            imageResults[3].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.SurvivorPerks[j].image);
                            debug = debug + "\n\n292\nPerk3: " + randomPerk3 + "\nName: " + smData.data.SurvivorPerks[j].name + "\nImage: " + smData.data.SurvivorPerks[j].image;
                        }

                        else if (smData.data.SurvivorPerks[j].id == randomPerk4)
                        {
                            imageResults[4].gameObject.GetComponent<SpriteRenderer>().sprite =
                                Resources.Load<Sprite>(smData.data.SurvivorPerks[j].image);
                            debug = debug + "\n\n299\nPerk4: " + randomPerk4 + "\nName: " + smData.data.SurvivorPerks[j].name + "\nImage: " + smData.data.SurvivorPerks[j].image;
                        }
                    }
                }
            }
        }

        else
        {
            SetEmptyIcon(0, 4, "Images/Killers/IconKiller_Killer");
        }

        ResetVariables();
    }

    private void SetEmptyIcon(int initial, int last, string path)
    {
        for (int i = initial; i <= last; i++)
        {
            imageResults[i].gameObject.GetComponent<SpriteRenderer>().sprite =
                                    Resources.Load<Sprite>(path);
        }
    }

    private void StopRotation(int row)
    {
        //Rows stopped and disabled
        rows[row].rowStopped = true;
        rows[row].gameObject.SetActive(false);

        //Results enabled
        imageResults[row].gameObject.SetActive(true);
    }

    private void ResetVariables()
    {
        randomCharacterList.Clear();
        randomPerkList.Clear();
        randomPerk1 = null;
        randomPerk2 = null;
        randomPerk3 = null;
        randomPerk4 = null;
    }
    public void DebugPopup()
    {
        PopupPanel.SetActive(true);
    }

    public void DebugPopupAccept()
    {
        PopupPanel.SetActive(false);
        smData.SaveIntoDebugging(debug);
    }

    public void DebugPopupCancel()
    {
        PopupPanel.SetActive(false);
    }

    private IEnumerator Stop()
    {
        //Coroutine to manage stops on each row 
        yield return new WaitForSeconds(1.5f);
        StopRotation(0);
        yield return new WaitForSeconds(1.5f);

        StopRotation(1);
        yield return new WaitForSeconds(0.5f);
        StopRotation(2);
        yield return new WaitForSeconds(0.5f);
        StopRotation(3);
        yield return new WaitForSeconds(0.5f);
        StopRotation(4);

        rotating = false;
    }
}

