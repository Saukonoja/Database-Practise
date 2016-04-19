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
            include("../Init/config.php");
            return "<tr><td><a href='" . $albumPage . "?link_track=". htmlspecialchars($this->track, ENT_QUOTES)."&link_album=".$this->album."'>".$this->track."</a></td>
                        <td><a href='" . $artistPage . "?link_artist=".$this->artist."'>" . $this->artist."</a></td>
                        <td><a href='" . $albumPage . "?link_album=".$this->album."'>".$this->album."</a></td>
                        <td id=year>".$this->year."</td></tr>";   
        }   
    }
 
?>