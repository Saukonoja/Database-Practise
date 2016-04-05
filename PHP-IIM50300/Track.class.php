<?php
 
    class Track{
        private $name;
        private $artist;
        private $album;
        private $year;
        private $company;
 
        function __construct($name, $artist, $album, $year, $company){
            $this->name = $name;
            $this->artist = $artist;
            $this->album = $album;
            $this->year = $year;
            $this->company = $company;
        }

        function __toString() {
            return "<tr><td><a href='track-page.php?link_track=".$this->name."'>".$this->name.
            "</a></td><td><a href='artist-page.php?link_artist=".$this->artist."'>" . $this->artist.
            "</a></td><td><a href='album-page.php?link_album=".$this->album."'>".$this->album.
            '</td><td>'.$this->year.'</td><td>'.$this->company.'</td></tr>';      
        }
    }
 
?>