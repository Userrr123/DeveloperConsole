using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;

namespace DevConsole
{
    public class CommandSpawnPrefab : ConsoleCommand
    {
        public static CommandSpawnPrefab csp;

        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }


        public CommandSpawnPrefab()
        {
            Name = "Spawn Prefab (<color=orange> /spawnPrefab </color>)";
            Command = "/spawnPrefab";
            Description = "Spawn a Prefab";
            Help = "Options: \n" +
                "x<value> where <value is the integer value of the x coordinate> \n" + 
                "y<value> where <value is the integer value of the y coordinate> \n" +
                "z<value> where <value is the integer value of the z coordinate> \n" +
                "prefab<value> where <value is the name of the Prefab that you want to spawn> \n" +
                "name<value> where <value is the name you want the spawned Prefab to have> \n" +
                "Full example => ( <color=orange>/spawnPrefab prefab=PrefabName name=AnyName x=1 y=1 z=1</color> ) \n" + 
                "You can also leave input parameters out or change their order: \n" +
                "e.g. ( <color=orange>/spawnPrefab prefab=PrefabName name=AnyName y=1</color> ) \n" +
                "e.g. ( <color=orange>/spawnPrefab x=1 prefab=PrefabName</color> ) \n" + 
                "etc...";

            AddCommandToConsole();
        }

        private void Awake()
        {
            csp = this;
        }

        public override void RunCommand(string[] args)
        {
            //Variables for Instantiation
            int x = 0, y = 0, z = 0;

            string prefabName = "";
            string objectName = "";

            for (int i = 0; i < args.Length; i++)
            {
                string arguement = args[i];

                string[] argSplit = Regex.Split(arguement, @"\=");

                // Find variable and change
                switch (argSplit[0])
                {
                    case "x":
                        x = int.Parse(argSplit[1]);
                        break;
                    case "y":
                        y = int.Parse(argSplit[1]);
                        break;
                    case "z":
                        z = int.Parse(argSplit[1]);
                        break;
                    case "prefab":
                        prefabName = argSplit[1];
                        break;
                    case "name":
                        objectName = argSplit[1];
                        break;
                }
            }

            if (prefabName == string.Empty || prefabName == "")
            {
                Debug.LogError("<color=red>The name of the Prefab is empty! For help use ( /spawnPreab -help )</color>");
                return;
            }
            // IMPORTANT: Comment the instantiation/spawning code out that you don´t need, like displayed here, otherwise it shows an error.

            // Instantiate a Prefab over the PhotonNetwork
            GameObject spawnedObject = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", prefabName), new Vector3(x, y, z), new Quaternion());

            // Instantiate a Prefab with Unity´s Instantiate() method.
            //GameObject spawnedObject = MonoBehaviour.Instantiate((GameObject)Resources.Load("PhotonPrefabs/" + prefabName), new Vector3(x,y,z), new Quaternion());

            SpawnedObjectsList.SOL.spawnedObjects.Add(spawnedObject);

            if(objectName == string.Empty || objectName == "")
            {
                spawnedObject.name = spawnedObject.name + UnityEngine.Random.Range(1, 1000);
            }
            else
            {
                spawnedObject.name = objectName;
            }
        }

        public static CommandSpawnPrefab CreateCommand()
        {
            return new CommandSpawnPrefab();
        }
    }
}
