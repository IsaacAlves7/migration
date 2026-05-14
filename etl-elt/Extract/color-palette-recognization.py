from PIL import Image
import matplotlib.pyplot as plt
import numpy as np
import collections

# Abrir a imagem
image_path = '/mnt/data/ef67f8ba-3ec9-4c6b-bd69-91d47499ab45.png'
image = Image.open(image_path).convert('RGB')

# Reduz a imagem para acelerar o processamento
small_img = image.resize((100, 100))
pixels = np.array(small_img).reshape(-1, 3)

# Contar cores
counter = collections.Counter(map(tuple, pixels))
most_common_colors = counter.most_common(6)  # Pegar as 6 cores principais

# Converter para hexadecimais
hex_colors = ['#%02x%02x%02x' % color for color, _ in most_common_colors]
print("Cores principais (hex):", hex_colors)