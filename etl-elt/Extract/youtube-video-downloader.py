import subprocess
# import ffmpeg
# import os

# Baixar o vídeo
def baixar_video_youtube(url, caminho_destino="./"):
    """
    Baixa um vídeo do YouTube usando youtube-dl via subprocess.
    
    Parâmetros:
        url (str): URL do vídeo do YouTube.
        caminho_destino (str): Caminho para salvar o vídeo.
    """
    try:
        # Comando para baixar o vídeo
        comando = [
            "yt-dlp",
            "--output", f"{caminho_destino}/%(title)s.%(ext)s",
            url
        ]
        # Executa o comando
        subprocess.run(comando, check=True)
        print("Download concluído com sucesso!")
    except subprocess.CalledProcessError as e:
        print(f"Erro ao baixar o vídeo: {e}")
    except FileNotFoundError:
        print("Certifique-se de que o youtube-dl está instalado no sistema.")

# Renomear o arquivo para a conversão
# def renomear_arquivo(caminho_antigo, caminho_novo):
#     """
#     Renomeia um arquivo.
    
#     Parâmetros:
#         caminho_antigo (str): Caminho do arquivo atual.
#         caminho_novo (str): Novo caminho/nome do arquivo.
#     """
#     try:
#         os.rename(caminho_antigo, caminho_novo)
#         print(f"Arquivo renomeado de '{caminho_antigo}' para '{caminho_novo}'")
#     except FileNotFoundError:
#         print("Arquivo não encontrado!")
#     except PermissionError:
#         print("Permissão negada para renomear o arquivo!")
#     except Exception as e:
#         print(f"Erro ao renomear o arquivo: {e}")

# # Converter o mesmo vídeo para audio
# def converter_video_para_audio(caminho_video="./", caminho_audio="./"):
#     '''
#     Deseja converter o vídeo baixado para audio? Y(es) ou N(o)

#     Se sim, convertendo vídeo em audio, para o formato de arquivo MP3
#     Se não, encerrar o programa
#     '''
#     """
#     Converte um vídeo em um arquivo de áudio usando FFmpeg.
    
#     Parâmetros:
#         caminho_video (str): Caminho do vídeo de entrada.
#         caminho_audio (str): Caminho do áudio de saída (com extensão .mp3 ou .wav).
#     """
#     try:
#         # Comando para extrair o áudio do vídeo
#         ffmpeg.input(caminho_video).output(caminho_audio).run()
#         print(f"Áudio salvo com sucesso em: {caminho_audio}")
#     except Exception as e:
#         print(f"Erro ao converter vídeo para áudio: {e}")

# Output
url_video = input('Link do video: ')  # Substitua pela URL desejada
baixar_video_youtube(url_video)
# renomear_arquivo("title.mp4", "video.mp4")
# converter_video_para_audio("video.mp4", "audio.mp3")