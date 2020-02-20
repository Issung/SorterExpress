# SorterExpress

Program to aid with the manual sorting of a large collection of images/videos. You can choose to sort your library by adding individual tags to files or using a unique note for each, and you may also move the file you are inspecting to a specific folder, folders in the directory you are working in are included automatically but you may also include custom directories.
Tags and notes are saved in a file's filename.

This project has a range of abilities at this point in time, including:
* Support for popular image formats and video formats (webm included).
* Adding tags & notes to files and moving them to desired folders.
* Viewing your collection by selecting desired tags with "AND", "OR" and "NOT" filtering.
* Renaming a tag across a whole selection of files.
* Finding duplicates in your library using a simple algorithm.

Here you can see the main sorting window. It features your tag collection on the left which is searchable, folder collection in the middle and image preview on the right with some extra controls to skip through your libarary. This will probably be where you spend most of your time if you wish to sort your library.
![Main sorting window](https://i.imgur.com/ieyN2iC.png)

Here is the duplicate search window, it searches for duplicate images in your collection, it works well for certain types of images (lewd in particular). It supports videos by taking the first frame of the video as an image. Can search recursively through all folders in a directory and is multithreaded to greatly speed up the searching process.
![Duplicate searching window](https://i.imgur.com/aZGtKIR.png)

## Prerequisites

This project uses [VLC](https://www.videolan.org/) for video support.
This project also uses [FFMPEG](https://www.ffmpeg.org/) to obtain video thumbnails and duration.

## Authors

* **[Joel](https://github.com/Issung)**

## Built With
* .NET 4.7
* Winforms

## License

The license of this project is currently undecided.

## Acknowledgments

* Hat tip to anyone whose code was used
* VLC
* FFMPEG
