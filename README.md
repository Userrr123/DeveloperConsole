Important:
I made 4 Scripts, that might be useful for you guys:

The first Script (SpawnedObjectsList) is just creating a list that stores all Prefabs, that have been spawned/instantiated with the Console.

The second Script (CommandSpawnPrefab) has the spawning/instantiation logic. (It spawns a Prefab by the name that you type in the Console).

The third Script (CommandDestroy) destroys a spawned Prefab. (It looks for the name of the Prefab, that you want to destroy, in the List and destroys it and also removes the empty spot from the List).

The fourth Script (CommandDestroyAll) destroys all spawned Prefabs. (It looks for the Prefabs in the List and destroys them and also removes the empty spots from the List).

If you use the Script with the spawn command, don´t forget to also add the first Script to your Folder, where the DeveloperConsole is.

IMOIRTANT: Don´t forget to change the "namespace" of the Scripts, since I used a different one!!!

PS.: The CommansSpawnPrefab doesn´t need to be a Singleton. 

You can remove the "public static CommandSpawnPrefab csp;" at the beginning of the Script and if you do so, also remove the Awake() function.
