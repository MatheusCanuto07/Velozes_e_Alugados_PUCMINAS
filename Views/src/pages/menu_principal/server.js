const express = require('express');
const { createProxyMiddleware } = require('http-proxy-middleware');

const app = express();

app.use('/api', createProxyMiddleware({
    target: 'https://localhost:7090',
    changeOrigin: true,
    secure: false
}));

app.use(express.static('public'));

app.listen(5501, () => {
    console.log('Server is running on http://127.0.0.1:5501');
});
