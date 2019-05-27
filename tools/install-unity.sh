#! /bin/sh

BASE_URL=https://netstorage.unity3d.com/unity
HASH=fc0fe30d6d91
VERSION=2018.3.8f1

getFileName() {
    echo "${UNITY_DOWNLOAD_CACHE}/`basename "$1"`"
}

download() {
    file=$1
    url="$BASE_URL/$HASH/$file"
    filePath=$(getFileName $file)
    fileName=`basename "$file"`

    if [ ! -e $filePath ] ; then
        echo "Downloading $filePath from $url: "
        curl --retry 5 -o "$filePath" "$url"
    else
        echo "$fileName exists in cache. Skipping download."
    fi
}

install() {
    package=$1
    filePath=$(getFileName $package)

    download "$package"

    echo "Installing $filePath"
    sudo installer -dumplog -package "$filePath" -target /

}

# See $BASE_URL/$HASH/unity-$VERSION-$PLATFORM.ini for complete list
# of available packages, where PLATFORM is `osx` or `win`

install "MacEditorInstaller/Unity-$VERSION.pkg"
install "MacEditorTargetInstaller/UnitySetup-Windows-Mono-Support-for-Editor-$VERSION.pkg"
install "MacEditorTargetInstaller/UnitySetup-Mac-IL2CPP-Support-for-Editor-$VERSION.pkg"