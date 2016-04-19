<?php
 
    class Track{
        private $name;
        private $artist;
        private $album;
        private $year;
 
        function __construct($name, $artist, $album, $year){
            $this->name = $name;
            $this->artist = $artist;
            $this->album = $album;
            $this->year = $year;
        }

        function __toString() {
            include("../Init/config.php");
                return "<tr><td><a href='" . $albumPage . "?link_track=".htmlspecialchars($this->name, ENT_QUOTES)."&link_album=".$this->album."'>".$this->name."</a></td>
                            <td><a href='" . $artistPage . "?link_artist=".$this->artist."'>" . $this->artist."</a></td>
                            <td><a href='" . $albumPage . "?link_album=".$this->album."'>".$this->album.'</td>
                            <td id=year>'.$this->year.'</td></tr>';      
        }
    }
 
?>