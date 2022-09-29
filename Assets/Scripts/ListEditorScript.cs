using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ListEditorScript : MonoBehaviour
{
    public RectTransform characterPrefab;
    public RectTransform perkPrefab;
    public ScrollRect scrollView;
    public RectTransform content;

    public Sprite checkImageTrue;
    public Sprite checkImageFalse;


    private Data editorData;

    List<PerkView> perkViews = new List<PerkView>();
    List<CharacterView> characterViews = new List<CharacterView>();

    // Start is called before the first frame update
    void Start()
    {
        editorData = GameObject.Find("GameManager").gameObject.GetComponent<Data>();
    }

    public void UpdateItems(string type)
    {
        if (type == "killer")
        {
            int newCount = editorData.data.Killers.Length;

            OnRecievedNewCharacterModels(FetchCharacterModelsFromServer(newCount, "killer"));
        }

        else if (type == "survivor")
        {
            int newCount = editorData.data.Survivors.Length;

            OnRecievedNewCharacterModels(FetchCharacterModelsFromServer(newCount, "survivor"));
        }

        else if (type == "killerPerks")
        {
            int newCount = editorData.data.KillerPerks.Length;

            OnRecievedNewPerkModels(FetchPerkModelsFromServer(newCount, "killer"));
        }

        else if (type == "survivorPerks")
        {
            int newCount = editorData.data.SurvivorPerks.Length;

            OnRecievedNewPerkModels(FetchPerkModelsFromServer(newCount, "survivor"));
        }
        

    }

    private void OnRecievedNewPerkModels(PerkModel[] models)
    {
        //Destroying existing objects in list
        foreach (Transform child in content)
            Destroy(child.gameObject);
        perkViews.Clear();

        //Adding new object to list
        int i = 0;
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(perkPrefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            var view = InitializePerkView(instance, model);
            perkViews.Add(view);

            i++;
        }
    }

    private void OnRecievedNewCharacterModels(CharacterModel[] models)
    {
        //Destroying existing objects in list
        foreach (Transform child in content)
            Destroy(child.gameObject);
        characterViews.Clear();

        //Adding new object to list
        int i = 0;
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(characterPrefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            var view = InitializeCharacterView(instance, model);
            characterViews.Add(view);

            i++;
        }
    }


    PerkView InitializePerkView(GameObject viewGameObject, PerkModel model)
    {
        //Creating a view of the prefab and entering values from the model
        PerkView view = new PerkView(viewGameObject.transform);

        view.nameText.text = model.name;
        view.descriptionText.text = model.description;
        view.iconImage.sprite = model.icon;
        view.checkImage.sprite = checkImageTrue;
        view.checkImage2.sprite = checkImageFalse;

        return view;
    }

    CharacterView InitializeCharacterView(GameObject viewGameObject, CharacterModel model)
    {
        //Creating a view of the prefab and entering values from the model
        CharacterView view = new CharacterView(viewGameObject.transform);

        view.nameText.text = model.name;
        view.iconImage.sprite = model.icon;
        view.checkImage.sprite = checkImageTrue;
        view.checkImage2.sprite = checkImageFalse;

        return view;
    }

    PerkModel[] FetchPerkModelsFromServer(int count, string role)
    {
        //Getting an array of models of the prefab with its values
        var results = new PerkModel[count];

        if (role == "killer")
        {
            for (int i = 0; i < count; i++)
            {
                results[i] = new PerkModel();
                results[i].name = editorData.data.KillerPerks[i].name;
                results[i].icon = Resources.Load<Sprite>(editorData.data.KillerPerks[i].image);
                results[i].description = editorData.data.KillerPerks[i].description;
            }

            return results;
        }

        else if (role == "survivor")
        {
            for (int i = 0; i < count; i++)
            {
                results[i] = new PerkModel();
                results[i].name = editorData.data.SurvivorPerks[i].name;
                results[i].icon = Resources.Load<Sprite>(editorData.data.SurvivorPerks[i].image);
                results[i].description = editorData.data.SurvivorPerks[i].description;
            }

            return results;
        }

        else return null;
        
    }

    CharacterModel[] FetchCharacterModelsFromServer(int count, string role)
    {
        //Getting an array of models of the prefab with its values
        var results = new CharacterModel[count];

        if (role == "killer")
        {
            for (int i = 0; i < count; i++)
            {
                results[i] = new CharacterModel();
                results[i].name = editorData.data.Killers[i].name;
                results[i].icon = Resources.Load<Sprite>(editorData.data.Killers[i].image);
            }

            return results;
        }

        else if (role == "survivor")
        {
            for (int i = 0; i < count; i++)
            {
                results[i] = new CharacterModel();
                results[i].name = editorData.data.Survivors[i].name;
                results[i].icon = Resources.Load<Sprite>(editorData.data.Survivors[i].image);
            }

            return results;
        }

        else return null;

    }




    public class PerkView
    {
        //Class view. Getting components for prefab
        public Text nameText, descriptionText;
        public Image iconImage, checkImage, checkImage2;


        public PerkView(Transform rootView)
        {
            nameText = rootView.Find("NameText").GetComponent<Text>();
            descriptionText = rootView.Find("DescriptionText").GetComponent<Text>();
            iconImage = rootView.Find("IconImage").GetComponent<Image>();
            checkImage = rootView.Find("CheckImage").GetComponent<Image>();
            checkImage2 = rootView.Find("CheckImage2").GetComponent<Image>();
        }
    }

    public class CharacterView
    {
        //Class view. Getting components for prefab
        public Text nameText;
        public Image iconImage, checkImage, checkImage2;


        public CharacterView(Transform rootView)
        {
            nameText = rootView.Find("NameText").GetComponent<Text>();
            iconImage = rootView.Find("IconImage").GetComponent<Image>();
            checkImage = rootView.Find("CheckImage").GetComponent<Image>();
            checkImage2 = rootView.Find("CheckImage2").GetComponent<Image>();
        }
    }


    public class PerkModel
    {
        //Class model. Getting value for prefab
        public string name, description;
        public Sprite icon;
    }

    public class CharacterModel
    {
        //Class model. Getting value for prefab
        public string name;
        public Sprite icon;
    }
}
