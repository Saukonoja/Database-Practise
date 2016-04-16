<?php
 
    class CompanyView{
        private $album;
        private $artist;
        private $year;
 
        function __construct($album, $artist, $year){    
            $this->album = $album;
            $this->artist = $artist;
            $this->year = $year;
        }

        function __toString() {
            return "<tr><td><a href='album-page.php?link_album=".$this->album."'>" . $this->album."</a></td>
                        <td><a href='artist-page.php?link_artist=".$this->artist."'>".$this->artist."</a></td>
                        <td id=year>".$this->year."</td></tr>";   
        }   
    }
 
?>