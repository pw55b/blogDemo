const PROXY_CONFIG = [
  {
      context: [
          "/api",
      ],
      target: "https://localhost:7001",
      secure: false
  },
  {
    context: [
        "/uploads",
    ],
    target: "https://localhost:7001",
    secure: false
}
]

module.exports = PROXY_CONFIG;