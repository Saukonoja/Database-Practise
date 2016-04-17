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
                return "<tr><td><a href='album-page.php?link_track=".$this->name."&link_album=".$this->album."'>".$this->name."</a></td>
                            <td><a href='artist-page.php?link_artist=".$this->artist."'>" . $this->artist."</a></td>
                            <td><a href='album-page.php?link_album=".$this->album."'>".$this->album.'</td>
                            <td id=year>'.$this->year.'</td></tr>';      
        }
    }
 
?>