# ppSlideExtract
Small utility to extract slides from PowerPoint (from HD up to 4K). Additionally areas of slides can be isolated onto a transparent background.
## Functions
### Basic
The basic functionaliy of this utility is to extract slides from PowerPoint files to .png images. As PowerPoint only exports 720p images natively, this could prove useful.
In every case, it exports all slides of the file (except mask slides, see below) in the given resolution to a given directory.
### Masking
The user can create mask slides in the PowerPoint file for extracting parts of every slide onto a transparent background (see below).
This is applied to every slide and exported seperately to .png images.
The mask slide should be grayscale. Black areas will be transparent.
### Shadowing
If the user provides an additional mask for shadowing, this mask will be applied to the extracts prior to saving the image.
The mask slide should be grayscale. Black areas will be dark (over transparent color)
##
![Preview of Utility](https://github.com/svenito92/ppSlideExtract/blob/master/Documentation/Images/Preview.png)
![Functionality of Utility](https://github.com/svenito92/ppSlideExtract/blob/master/Documentation/Images/Functionality.png)
