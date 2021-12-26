using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Photon.Pun;
using System.IO;

namespace DevConsole
{
    public class CommandDestroy : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        private int objectIndex;

        public CommandDestroy()
        {
            Name = "Destroy Spawned Prefab (<color=orange> /destroy </color>)";
            Command = ("/destroy");
            Description = "Destroys a spawned Prefab, by it´s name, that is stored in the List";
            Help = "Options: \n" +
                "prefab<value> where <value is the name of the Prefab that you want to destroy> \n" +
                "e.g. ( <color=orange>/destroy prefab=PrefabName</color> )";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string prefabName = "";

            for (int i = 0; i < args.Length; i++)
            {
                string arguement = args[i];

                string[] argSplit = Regex.Split(arguement, @"\=");

                // Find variable and change
                switch (argSplit[0])
                {
                    case "prefab":
                        prefabName = argSplit[1];
                        break;
                }
            }

            if(prefabName == "" || prefabName == string.Empty)
            {
                Debug.LogError("<color=red>The name of the Prefab is empty! For help use ( /destroy -help )</color>");
                return;
            }
            else
            {
                //Destroy
                foreach (GameObject spawnedObject in SpawnedObjectsList.SOL.spawnedObjects)
                {
                    if (spawnedObject.name == prefabName)
                    {
                        //Get index of destroyed Object in List
                        objectIndex = SpawnedObjectsList.SOL.spawnedObjects.IndexOf(spawnedObject);

                        //Destroy the Object with the wanted name
                        PhotonNetwork.Destroy(spawnedObject);
                    }
                }
                //Remove empty Slot in List
                SpawnedObjectsList.SOL.spawnedObjects.RemoveAll(objectIndex => string.IsNullOrEmpty(string.Empty));
            }
        }

        public static CommandDestroy CreateCommand()
        {
            return new CommandDestroy();
        }
    }
}
