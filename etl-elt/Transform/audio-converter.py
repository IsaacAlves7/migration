from pydub import AudioSegment

# Definir novamente o caminho do arquivo
file_path = "/mnt/data/Quanqueu - WhatsApp Audio 2025-03-16 at 17.10.05.ogg"

# Converter para WAV
wav_path = "/mnt/data/temp_audio.wav"
audio = AudioSegment.from_file(file_path, format="ogg")
audio.export(wav_path, format="wav")

print(wav_path)
