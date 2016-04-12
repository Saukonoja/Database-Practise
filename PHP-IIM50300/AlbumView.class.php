﻿<?php
 
    class AlbumView{
        private $number;
        private $track;
        private $length;
 
        function __construct($number, $track, $length){
            $this->number = $number;
            $this->track = $track;
            $this->length = $length;
        }

        function __toString() {
            return '<tr><td id=number>' . $this->number. "</td><td id=track><a href='album-page.php?link_track=".$this->track."'>" . $this->track. '</td><td id=length>' 
            . gmdate("i:s", $this->length). '</td>'; 
        }
        function albumInfo($artist, $year, $row_count, $length){
            return "<p id='albumInfo'>from artist <span id='artist'><a href='artist-page.php?link_artist=". $artist."'>" . $artist. '</a></span> &#9679; ' .$year. ' &#9679; ' .$row_count. ' tracks, '
            .gmdate("i:s", $length).'</p>';
        }

        function youtubeVideo($tube){
            return "<object width='700px' height='400' data='http://www.youtube.com/v/".$tube."?autoplay=1' type='application/x-shockwave-flash'><param name='src' value='http://www.youtube.com/v/".$tube."?autoplay=1'/></object>";
        }
        
    }
 
?>