# Defina a imagem base
FROM node:14-alpine

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie os arquivos de pacote e o arquivo de bloqueio de versão
COPY package.json package-lock.json ./

# Instale as dependências do projeto
RUN yarn install --frozen-lockfile

# Copie o restante dos arquivos do projeto
COPY . .

# Construa a aplicação React
RUN npm run build

# Instale o servidor estático globalmente
RUN yarn global add serve

# Configure o comando para iniciar o servidor da aplicação
CMD ["serve", "-s", "build", "-l", "3000"]