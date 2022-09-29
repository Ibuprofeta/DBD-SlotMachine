using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditorScript : MonoBehaviour
{
    [SerializeField] private GameObject characterController;
    [SerializeField] private GameObject perksController;
    private Data editorData;


    private int characterCounter;
    private bool moreIterations;
    private bool killerActive;
    public string selectedCharacterId;
    private string selectedRole;
    private bool next;
    private bool prev;
    public bool savedPerks;
    public bool savedKillers;
    public bool savedSurvivors;
    private int maxSelectionCharacterPosition;
    private int maxSelectionPerksPosition;
    private int selectionCharacterPosition;
    private int selectionPerksPosition;
    private GameObject selectedCharacter;
    [SerializeField] private GameObject savePerks;
    [SerializeField] private GameObject saveKillers;
    [SerializeField] private GameObject saveSurvivors;
    [SerializeField] private GameObject saveCharacter;
    void Start()
    {
        editorData = gameObject.GetComponent<Data>();

        killerActive = true;
        next = false;
        prev = false;
        savedPerks = true;
        savedKillers = true;
        savedSurvivors = true;
        selectionCharacterPosition = 0;
        selectionPerksPosition = 0;

        SelectionCount();

        //UpdateKillers();

    }
    private void UpdateKillers()
    {
        moreIterations = true;
        characterCounter = 0;

        for (int selectionPanel = 0; selectionPanel < characterController.transform.childCount; selectionPanel++)
        {
            if (moreIterations)
            {
                for (int imageCounter = 0; imageCounter < characterController.transform.GetChild(selectionPanel).transform.childCount; imageCounter++)
                {
                    if (characterCounter < editorData.data.Killers.Length)
                    {
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<Image>().sprite = Resources.Load<Sprite>(editorData.data.Killers[characterCounter].image);
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().id = editorData.data.Killers[characterCounter].id;
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().active= editorData.data.Killers[characterCounter].active;
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().role = "Killer";
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).
                            GetComponent<CharacterData>().Setup();
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(true);
                    }

                    else
                    {
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(false);
                        moreIterations = false;
                    }
                    characterCounter++;
                }
            }

            else
            {
                characterController.transform.GetChild(selectionPanel).gameObject.SetActive(false);
            }
        }
    }

    private void UpdateSurvivors()
    {
        moreIterations = true;
        characterCounter = 0;

        for (int selectionPanel = 0; selectionPanel < characterController.transform.childCount; selectionPanel++)
        {
            if (moreIterations)
            {
                for (int imageCounter = 0; imageCounter < characterController.transform.GetChild(selectionPanel).transform.childCount; imageCounter++)
                {
                    if (characterCounter < editorData.data.Survivors.Length)
                    {
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<Image>().sprite = Resources.Load<Sprite>(editorData.data.Survivors[characterCounter].image);
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().id = editorData.data.Survivors[characterCounter].id;
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().active = editorData.data.Survivors[characterCounter].active;
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().role = "Survivor";
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).
                            GetComponent<CharacterData>().Setup();
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(true);
                    }

                    else
                    {
                        characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(false);
                        moreIterations = false;
                    }
                    characterCounter++;
                }
            }

            else
            {
                characterController.transform.GetChild(selectionPanel).gameObject.SetActive(false);
            }
        }
    }

    private void UpdatePerks(string role, string id)
    {
        bool moreIterations = true;
        int perksCounter = 0;
        int characterPosition = 0;


        if (role == "Killer")
        {
            for (int i = 0; i < editorData.data.Killers.Length; i++)
            {
                if (editorData.data.Killers[i].id == id)
                {
                    characterPosition = i;
                }
            }
        }

        else if (role == "Survivor")
        {
            for (int i = 0; i < editorData.data.Survivors.Length; i++)
            {
                if (editorData.data.Survivors[i].id == id)
                {
                    characterPosition = i;
                }
            }  
        }
        

        for (int selectionPanel = 0; selectionPanel < perksController.transform.childCount; selectionPanel++)
        {
            if (moreIterations)
            {
                for (int imageCounter = 0; imageCounter < perksController.transform.GetChild(selectionPanel).transform.childCount; imageCounter++)
                {
                    if (role == "Killer")
                    {
                        if (perksCounter < editorData.data.KillerPerks.Length)
                        {
                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                GetComponent<Image>().sprite = Resources.Load<Sprite>(editorData.data.KillerPerks[perksCounter].image);
                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                GetComponent<PerkData>().id = editorData.data.KillerPerks[perksCounter].id;

                            for (int i = 0; i < editorData.data.Killers[characterPosition].Perks.Length; i++)
                            {
                                if (editorData.data.Killers[characterPosition].Perks[i].id == editorData.data.KillerPerks[perksCounter].id)
                                {
                                    perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                        GetComponent<PerkData>().active = editorData.data.Killers[characterPosition].Perks[i].active;
                                    perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                        GetComponent<PerkData>().Setup();
                                }
                            }

                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                GetComponent<PerkData>().id = editorData.data.KillerPerks[perksCounter].id;

                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(true);
                        }

                        else
                        {
                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(false);
                            moreIterations = false;
                        }
                        perksCounter++;
                    }

                    else if (role == "Survivor")
                    {
                        if (perksCounter < editorData.data.SurvivorPerks.Length)
                        {
                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                GetComponent<Image>().sprite = Resources.Load<Sprite>(editorData.data.SurvivorPerks[perksCounter].image);
                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                GetComponent<PerkData>().id = editorData.data.SurvivorPerks[perksCounter].id;

                            for (int i = 0; i < editorData.data.Survivors[characterPosition].Perks.Length; i++)
                            {
                                if (editorData.data.Survivors[characterPosition].Perks[i].id == editorData.data.SurvivorPerks[perksCounter].id)
                                {
                                    perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                        GetComponent<PerkData>().active = editorData.data.Survivors[characterPosition].Perks[i].active;
                                    perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                                        GetComponent<PerkData>().Setup();
                                }
                            }

                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(true);
                        }

                        else
                        {
                            perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.SetActive(false);
                            moreIterations = false;
                        }
                        perksCounter++;
                    }
                }
            }

            else
            {
                perksController.transform.GetChild(selectionPanel).gameObject.SetActive(false);
            }
        }

    }

    private void SelectionCount()
    {
        if (editorData.data.Killers.Length >= editorData.data.Survivors.Length)
            maxSelectionCharacterPosition = editorData.data.Killers.Length / 8;

        else
            maxSelectionCharacterPosition = editorData.data.Survivors.Length / 8;

        if (editorData.data.KillerPerks.Length >= editorData.data.SurvivorPerks.Length)
            maxSelectionPerksPosition = editorData.data.KillerPerks.Length / 48;

        else
            maxSelectionPerksPosition = editorData.data.SurvivorPerks.Length / 48;
    }

    public void UpdateCharacterPerks()
    {
        selectedCharacter = EventSystem.current.currentSelectedGameObject.gameObject;
        selectedCharacterId = EventSystem.current.currentSelectedGameObject.GetComponent<CharacterData>().id;
        selectedRole = EventSystem.current.currentSelectedGameObject.GetComponent<CharacterData>().role;
        UpdatePerks(selectedRole, selectedCharacterId);
    }


    public void SwapCharacterEditor()
    {
        if (killerActive)
        {
            UpdateSurvivors();
            killerActive = false;
        }

        else
        {
            UpdateKillers();
            killerActive = true;
        }
    }

    public void UpdateCharacterData()
    {
        if (killerActive)
            UpdateKillerData();


        else
            UpdateSurvivorData();

    }

    private void UpdateKillerData()
    {
        moreIterations = true;
        characterCounter = 0;

        for (int selectionPanel = 0; selectionPanel < characterController.transform.childCount; selectionPanel++)
        {
            if (moreIterations)
            {
                for (int imageCounter = 0; imageCounter < characterController.transform.GetChild(selectionPanel).transform.childCount; imageCounter++)
                {
                    if (characterCounter < editorData.data.Killers.Length)
                    {
                        if (characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().id== editorData.data.Killers[characterCounter].id)
                        {
                            editorData.data.Killers[characterCounter].active = characterController.transform.GetChild(selectionPanel).
                                transform.GetChild(imageCounter).gameObject.GetComponent<CharacterData>().active;
                        }
                    }

                    else
                    {
                        moreIterations = false;
                    }
                    characterCounter++;
                }
            }
        }
    }

    private void UpdateSurvivorData()
    {
        moreIterations = true;
        characterCounter = 0;

        for (int selectionPanel = 0; selectionPanel < characterController.transform.childCount; selectionPanel++)
        {
            if (moreIterations)
            {
                for (int imageCounter = 0; imageCounter < characterController.transform.GetChild(selectionPanel).transform.childCount; imageCounter++)
                {
                    if (characterCounter < editorData.data.Survivors.Length)
                    {
                        if (characterController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.
                            GetComponent<CharacterData>().id == editorData.data.Survivors[characterCounter].id)
                        {
                            editorData.data.Survivors[characterCounter].active = characterController.transform.GetChild(selectionPanel).
                                transform.GetChild(imageCounter).gameObject.GetComponent<CharacterData>().active;
                        }
                    }

                    else
                    {
                        moreIterations = false;
                    }
                    characterCounter++;
                }
            }
        }
    }

    private void UpdatePerkData()
    {
        bool moreIterations = true;
        int perksCounter = 0;
        int characterPosition = 0;


        if (selectedRole == "Killer")
        {
            for (int i = 0; i < editorData.data.Killers.Length; i++)
            {
                if (editorData.data.Killers[i].id == selectedCharacterId)
                {
                    characterPosition = i;
                }
            }
        }

        else if (selectedRole == "Survivor")
        {
            for (int i = 0; i < editorData.data.Survivors.Length; i++)
            {
                if (editorData.data.Survivors[i].id == selectedCharacterId)
                {
                    characterPosition = i;
                }
            }
        }


        for (int selectionPanel = 0; selectionPanel < perksController.transform.childCount; selectionPanel++)
        {
            if (moreIterations)
            {
                for (int imageCounter = 0; imageCounter < perksController.transform.GetChild(selectionPanel).transform.childCount; imageCounter++)
                {
                    if (selectedRole == "Killer")
                    {
                        if (perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.activeSelf)
                        {
                            for (int i = 0; i < editorData.data.Killers[characterPosition].Perks.Length; i++)
                            {
                                if (editorData.data.Killers[characterPosition].Perks[i].id == editorData.data.KillerPerks[perksCounter].id)
                                {
                                    editorData.data.Killers[characterPosition].Perks[i].active = perksController.transform.GetChild(selectionPanel).
                                        transform.GetChild(imageCounter).gameObject.GetComponent<PerkData>().active;
                                }
                            }
                        }

                        else
                        {
                            moreIterations = false;
                        }
                        perksCounter++;
                    }

                    else if (selectedRole == "Survivor")
                    {
                        if (perksController.transform.GetChild(selectionPanel).transform.GetChild(imageCounter).gameObject.activeSelf)
                        {
                            for (int i = 0; i < editorData.data.Survivors[characterPosition].Perks.Length; i++)
                            {
                                if (editorData.data.Survivors[characterPosition].Perks[i].id == editorData.data.SurvivorPerks[perksCounter].id)
                                {
                                    editorData.data.Survivors[characterPosition].Perks[i].active = perksController.transform.GetChild(selectionPanel).
                                        transform.GetChild(imageCounter).gameObject.GetComponent<PerkData>().active;
                                }
                            }
                        }


                        else
                        {
                            moreIterations = false;
                        }
                        perksCounter++;
                    }
                }
            }
        }
    }

    public void ActivateCharacter()
    {
        if (selectedCharacter != null){
            selectedCharacter.GetComponent<CharacterData>().Activate();
        }
    }

    public void SaveJsonPopup(string role)
    {
        if (role == "Perk")
        {
            savePerks.SetActive(true);
        }

        else if (role == "Killer")
        {
            saveKillers.SetActive(true);
        }
        
        else if (role == "Survivor")
        {
            saveSurvivors.SetActive(true);
        }

        else if (role == "Char")
        {
            saveCharacter.SetActive(true);
        }

    }

    public void SaveJsonData(string role)
    {
        if (role == "Perk")
        {
            UpdatePerkData();
            editorData.SaveIntoJson();
            print("saved");
            savePerks.SetActive(false);
            savedPerks = true;
        }

        else if (role == "Killer")
        {
            UpdateKillerData();
            editorData.SaveIntoJson();
            print("saved");
            saveKillers.SetActive(false);
            savedKillers = true;
        }

        else if (role == "Survivor")
        {
            UpdateSurvivorData();
            editorData.SaveIntoJson();
            print("saved");
            saveSurvivors.SetActive(false);
            savedSurvivors = true;
        }

        else if (role == "Char")
        {
            UpdateCharacterData();
            editorData.SaveIntoJson();
            saveCharacter.SetActive(false);
        }
    }

    public void CancelJsonData(string role)
    {
        if (role == "Perk")
        {
            savePerks.SetActive(false);
            savedPerks = true;
        }

        else if (role == "Killer")
        {
            saveKillers.SetActive(false);
            savedKillers = true;
        }

        else if (role == "Survivor")
        {
            saveSurvivors.SetActive(false);
            savedSurvivors = true;
        }

        else if (role == "Char")
        {
            saveCharacter.SetActive(false);
        }
    }

    public void NextCharacters()
    {
        next = true;
        if (selectionCharacterPosition < maxSelectionCharacterPosition)
        {
            StartCoroutine("MoveCharactersPanel");    
        }

        else
            next = false;
    }

    public void PrevCharacters()
    {
        prev = true;
        if (selectionCharacterPosition > 0)
        {
            StartCoroutine("MoveCharactersPanel");
        }

        else
            prev = false;
    }

    public void NextPerks()
    {
        next = true;
        if (selectionPerksPosition < maxSelectionPerksPosition)
        {
            StartCoroutine("MovePerksPanel");
        }

        else
            next = false;
    }

    public void PrevPerks()
    {
        prev = true;
        if (selectionPerksPosition > 0)
        {
            StartCoroutine("MovePerksPanel");
        }

        else
            prev = false;
    }

    private IEnumerator MoveCharactersPanel()
    {
        while (next)
        {
            characterController.transform.Translate(0, 50f, 0f);

            if (selectionCharacterPosition == 0 && characterController.transform.localPosition.y > 840f)
            {
                selectionCharacterPosition++;
                next = false;
            }
                

            else if (selectionCharacterPosition == 1 && characterController.transform.localPosition.y > 1740f)
            {
                selectionCharacterPosition++;
                next = false;
            }

            else if (selectionCharacterPosition == 2 && characterController.transform.localPosition.y > 2540f)
            {
                selectionCharacterPosition++;
                next = false;
            }

            else if (selectionCharacterPosition == 3 && characterController.transform.localPosition.y > 3440f)
            {
                selectionCharacterPosition++;
                next = false;
            }

            else if (selectionCharacterPosition == 4 && characterController.transform.localPosition.y > 4240f)
            {
                selectionCharacterPosition++;
                next = false;
            }

            yield return new WaitForSeconds(0.005f);
        }

        while (prev)
        {
            characterController.transform.Translate(0, -50f, 0f);

            if (selectionCharacterPosition == 1 && characterController.transform.localPosition.y < 40f)
            {
                selectionCharacterPosition--;
                prev = false;
            }
                
            else if (selectionCharacterPosition == 2 && characterController.transform.localPosition.y < 840f)
            {
                selectionCharacterPosition--;
                prev = false;
            }

            else if (selectionCharacterPosition == 3 && characterController.transform.localPosition.y < 1800f)
            {
                selectionCharacterPosition--;
                prev = false;
            }

            else if (selectionCharacterPosition == 4 && characterController.transform.localPosition.y < 2600f)
            {
                selectionCharacterPosition--;
                prev = false;
            }

            else if (selectionCharacterPosition == 5 && characterController.transform.localPosition.y < 3500f)
            {
                selectionCharacterPosition--;
                prev = false;
            }


            yield return new WaitForSeconds(0.005f);
        }
    }

    private IEnumerator MovePerksPanel()
    {
        while (next)
        {
            perksController.transform.Translate(-50f, 0, 0);

            if (selectionPerksPosition == 0 && perksController.transform.localPosition.x < -1150f)
            {
                selectionPerksPosition++;
                next = false;
            }

            else if  (selectionPerksPosition == 1 && perksController.transform.localPosition.x < -2350f)
            {
                selectionPerksPosition++;
                next = false;
            }

            else if (selectionPerksPosition == 1 && perksController.transform.localPosition.x < -3550f)
            {
                selectionPerksPosition++;
                next = false;
            }

            else if (selectionPerksPosition == 1 && perksController.transform.localPosition.x < -4750f)
            {
                selectionPerksPosition++;
                next = false;
            }

            yield return new WaitForSeconds(0.005f);
        }

        while (prev)
        {
            perksController.transform.Translate(50f, 0, 0);

            if (selectionPerksPosition == 1 && perksController.transform.localPosition.x > -40f)
            {
                selectionPerksPosition--;
                prev = false;
            }

            else if (selectionPerksPosition == 2 && perksController.transform.localPosition.x > -1150f)
            {
                selectionPerksPosition--;
                prev = false;
            }

            else if (selectionPerksPosition == 3 && perksController.transform.localPosition.x > -2350f)
            {
                selectionPerksPosition--;
                prev = false;
            }

            else if (selectionPerksPosition == 4 && perksController.transform.localPosition.x > -3550f)
            {
                selectionPerksPosition--;
                prev = false;
            }

            yield return new WaitForSeconds(0.005f);
        }
    }

}

