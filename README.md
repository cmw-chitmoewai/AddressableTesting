
# Addressable Asset
(Version 1.2.4)

Have Fun ! ki ki


# What is Unity Addressable System?
- Addressables is a Unity Editor and runtime asset management system.
- Addressable Asset System provides an easy way to load assets by “address”.
- Any asset, including scenes, prefabs, text assets, etc. can be marked as addressable.

  
# Install Addressable Package

  - Install Addressable Package from Window Menu-> Package Manager -> Addressable
  - Open Addressable Window (Window Menu -> Asset Management -> Addressable)

# Development
>Addressable assets can be grouped together for building and 
>loading as built-in content or into bundles for loading dynamically at runtime.

In The Addressables window :

* [Built in Data] [df1]- include scene list and resources of Editor
* [Default Local Group (Default)]  [df1]- for local assset (Default)

You can create another groups for both local and remote assset.
In addressable Window, Create New Group -> Click "Packed Assets"
then you can create and name it you like..
For Example
```sh
 Local Group
 Remote Group
```

# How to add your assets to Addressable Window

  - After you install addressable package , addressable appear in Inspector panel   of each asset when you select any assets from Project Window.
  - If you want that asset to be addressble Asset , tick addressable and name it    you want then that asset will be in Adddressable Window
  
You can also:

- manage and change group all assets in Addressable Window
  
## Code for Local Asset

```sh
 public AssetReference localNo;
 private void Start()
 {
      localNo.InstantiateAsync(Vector3.zero, Quaternion.identity);
 }
```

## Remote Asset
 You should create a group for all remote assset then you'll be easy to upload these asset to a server or storage something like that.... 
 
Click :
 ```sh
 Proile Tab of Addressable Window
```

Tick:
```sh
 Build Remote Calalog
then choose "RemoteBuildPath" for Remote Catalog Build Path
and "RemoteLoadPath" for Remote Catalog Load Path
```

Insert Link:
 ```sh
 Insert a storage link that you will store your remote assets to->
 "RemoteLoadPath" of Profile Entries
 for Example," https://your link...bla bla bla/[BuildTarget]"
```
 Then...
 Select your Remote Group
 ```sh
 Build Remote Calalog
then choose "RemoteBuildPath" for Remote Catalog Build Path
and "RemoteLoadPath" for Remote Catalog Load Path
```
 # code for remote asset
 you can see in the link below:
 https://github.com/cmw-chitmoewai/AddressableTesting.git
 
 You need to set up more in Addressable Window before you build your remote asset bundle:

Choose:
  ```sh
 "Packed Play Mode" in Play Mode Script TAB
```
 Finally you can build your remote asset group:
  ```sh
 "Build Player Conent" in Build TAB
```
 
You can see:
  - "ServerData" folder in you project after you build
  - in the folder, include 3 files (.hash / . json/ .bundle)
  - You need to upload these files to your storage or server something like that

>Now you can run Unity Editor and see your remote asset 

And of course Addressable Project is open source with a public repository
on GitHub.

See [GitHub](https://github.com/cmw-chitmoewai/AddressableTesting.git)


