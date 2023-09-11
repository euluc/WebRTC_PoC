# Proof of Concept: Multiplayer with WebRTC for Unity
This is a proof of concept made for testing WebRTC multiplayer within Unity! <br>

<h2> Goals </h2>
<p>
	This POC had two main goals: <br>
	<b> 1: To create a window that constantly uploads a file to a webserver. </b> <br>
	<b> 2: To have a multiplayer lobby where multiple clients are able to connect and see objects the same file contained within the webserver. </b> <br>
</p>

<h2> Problems </h2>
<h4> <p> Problem 1: The uploading window </p> </h4>
<p>
	The idea here is to create a simple GUI that has a file selector, an upload button and a terminal to check for errors. With that,
  you will be able to upload the file to a webserver with a predefined IP address.
</p>
<h4> <p> Problem 2: The lobby </p> </h4>
<p>
	For this, we wanted to be able to connect on lobby that will retrieve to file contained on the webserver based on its IP and on
  the file name. Then, show this file on the scene (assuming that this file is either an image or a video; something that can be
  converted into a texture), and everyone connected to the lobby will be able to see this file at the same time.
</p>

<h2> Achieved </h2>
<p>
  Until now, only the uploading window was created. It uploads the file to a webserver that has the predefined IP written on the
  code and allows file uploading.
</p>
