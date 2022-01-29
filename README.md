# By A Thread

CSCI 526 Project

NOTE: uses Unity Version 2020.3.26f1

## Cloning and setting up
To correctly clone and work with this repository, you need to perform a few preliminary steps. Instructions here adapted from https://en.joysword.com/posts/2016/03/setting_up_github_for_unity_projects/#clone-the-repository-for-other-team-members.

### Git LFS

To install git lfs on mac, run `brew install git-lfs` to install through homebrew, or download from the website.

To install git lfs on Windows, download the installer from the [official website](https://git-lfs.github.com/) and run. Afterwards, run `git lfs install` into git bash to activate.

### Configure Unity Smart Merge

To configure Unity Smart Merge, you first need to locate it's installation.

On Mac, when using Unity Hub, the path will look something like this:

```
/Applications/Unity/Hub/Editor/2020.3.26f1/Unity.app/Contents/Tools/UnityYAMLMerge
```

If you are not using Unity Hub, the path will look more like this:
```
/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge
```

On Windows, if not using Unity Hub, it will be location at:
```
C:\Program Files\Unity\Editor\Data\Tools\UnityYAMLMerge.exe
```

There currently is no reference available for it's path when using Unity Hub on Windows, if anyone locates it please add it here.

Then, edit the `~/.gitconfig` file located in your home directory, or the settings of any custom git client you are using, to add the following lines: (make sure to substitute your path for UnityYAMLMerge!)

```
[merge]
  tool = unityyamlmerge

[mergetool "unityyamlmerge"]
  trustExitCode = false
  cmd = '<path to UnityYAMLMerge>' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

### Setting Up Unity Editor

To best use this repo out-of-the-box, follow the steps for initializing a blank Unity project and git repo here:
https://en.joysword.com/posts/2016/03/setting_up_github_for_unity_projects/#clone-the-repository-for-other-team-members

Note that this repo nests the Unity Project in 1 inner folder, which is different from the stated instructions.


### Setting up a custom Unity script editor

To use VSCode as your preferred editor, follow these instructions:

https://code.visualstudio.com/docs/other/unity

| Note that using VSCode will require you to separately install `mono` and the `.NET Core SDK`

To use JetBrains Rider as your preferred editor, follow these instructions:

https://www.jetbrains.com/help/rider/Unity.html#getting-started

## You're all set!
