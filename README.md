# myVolumeToggeler
for Logitech G933 headsets, toggle volume levels of each application without modifying the system volume.

I absolutely Love the G933, and the fact that I can connect my phone to the adapter and take calls while gaming without removing the headphones.
however, I figured that the windows system volume also controls the volume of the aux input, which is so dumb.
so, I have made an exe. It basically reduces the volume of all the apps running on windows to 10% without changing the system volume. the next time you run the exe, it brings back the 10% of each application to 100%.
(program plays the windows default Exclamation sound when reducing the volume, that way you know that it is working)

now, just the exe is not impressive, I have bound one of the G keys on the headset itself to run the exe using Logitech gaming software. Whenever I want to receive a call, i just press the Gkey. and press it again when the call ends. no need to stop my gaming session!
go ahead and download the program from the git repo at:
https://github.com/demiGod095/myVolumeToggeler/raw/master/myVolumeToggler.exe

for those skeptics out there, feel free to download the source and compile the exe yourself, I used visual studio 2017 community for the task. hence the format of the repo. you can download the Program.cs file if you just want the code.
Repo link : https://github.com/demiGod095/myVolumeToggeler.git
I also would love to hear your experience, if it works or it doesn't. are any processes being ignored when using the toggle?

Open for suggestions on improvements/future releases.
Anyone who wants to add features, please do so by creating a pull request if you would like to share it with others :)
Also, do let me know if someone has already done this. I tried searching for it, but couldn't find anything like it.
kudos to this stack-overflow page for showing me how to control the volume mixer.
https://stackoverflow.com/questions/14306048/controlling-volume-mixer
Thank you.
