import requests
from bs4 import BeautifulSoup

# URL do site que você quer extrair o texto
url = input("Insira a URL: ")

# Cabeçalhos para evitar bloqueios e simular um navegador
headers = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) "
                  "AppleWebKit/537.36 (KHTML, like Gecko) "
                  "Chrome/120.0.0.0 Safari/537.36"
}

# Faz a requisição
response = requests.get(url, headers=headers)

# Verifica se a resposta foi bem-sucedida
if response.status_code == 200:
    # Parseia o HTML
    soup = BeautifulSoup(response.text, "html.parser")

    # Remove scripts, estilos e elementos que não são texto visível
    for script in soup(["script", "style", "noscript"]):
        script.extract()

    # Extrai o texto visível da página
    texto = soup.get_text(separator="\n", strip=True)

    print("Texto extraído do site:\n")
    print(texto)
else:
    print(f"Erro ao acessar {url}. Código HTTP: {response.status_code}")
