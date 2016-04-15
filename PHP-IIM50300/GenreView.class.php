<?php
 
    class GenreView{
        private $track;
        private $artist;
        private $album;
        private $year;
 
        function __construct($track, $artist, $album, $year){
            $this->track = $track;
            $this->artist = $artist;
            $this->album = $album;
            $this->year = $year;
        }

        function __toString() {
            return "<tr><td><a href='track-page.php?link_track=".$this->track."'>".$this->track."</a></td>
                        <td><a href='artist-page.php?link_artist=".$this->artist."'>" . $this->artist."</a></td>
                        <td><a href='album-page.php?link_album=".$this->album."'>".$this->album."</a></td><td>".$this->year."</td></tr>";   
        }   
    }
 
?>