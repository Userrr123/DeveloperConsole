using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Photon.Pun;
using System.IO;

namespace DevConsole
{
    public class CommandDestroyAll : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        private int objectIndex;

        public CommandDestroyAll()
        {
            Name = "Destroy All Spawned Prefabs (<color=orange> /destroyAll </color>)";
            Command = ("/destroyAll");
            Description = "Destroys all spawned Prefabs that are stored in the List";
            Help = "Options: \n" +
                "e.g. ( <color=orange>/destroyAll</color> )";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            foreach (GameObject spawnedObject in SpawnedObjectsList.SOL.spawnedObjects)
            {
                //IMPORTANT: Comment the code out, that you don´t need, like displayed below, so you don´t get any errors.

                //Destroy Prefabs instantiated/spawned over the PhotonNetwork
                PhotonNetwork.Destroy(spawnedObject);

                //Destroy Prefabs instantiated/spawned with Unity
                //MonoBehaviour.Destroy(spawnedObject);
            }
            //Remove empty Slots in List
            SpawnedObjectsList.SOL.spawnedObjects.Clear();
        }

        public static CommandDestroyAll CreateCommand()
        {
            return new CommandDestroyAll();
        }
    }
}
