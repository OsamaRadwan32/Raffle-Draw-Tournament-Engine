window.drawSounds = {
  shuffleAudio: null,
  selectAudio: null,

  playShuffle() {
    if (!this.shuffleAudio) {
      this.shuffleAudio = new Audio("/sounds/shuffle.mp3");
      this.shuffleAudio.loop = true;
      this.shuffleAudio.volume = 0.6;
    }
    this.shuffleAudio.currentTime = 0;
    this.shuffleAudio.play();
  },

  stopShuffle() {
    if (this.shuffleAudio) {
      this.shuffleAudio.pause();
      this.shuffleAudio.currentTime = 0;
    }
  },

  playSelect() {
    if (!this.selectAudio) {
      this.selectAudio = new Audio("/sounds/goodResult.mp3");
      this.selectAudio.volume = 0.9;
    }
    this.selectAudio.currentTime = 0;
    this.selectAudio.play();
  },
};
