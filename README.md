# Proyecto: Asistente IA con Semantic Kernel y Azure Search

Este proyecto implementa un sistema de Recuperaci�n Aumentada Generativa (RAG) utilizando **Semantic Kernel** y **Azure Search IA**. Se exponen dos endpoints principales:

1. **Consulta libre:** Permite realizar preguntas al modelo GPT-3.5 sin restricciones.
2. **Consulta con roles:** Solo responde preguntas dentro del contexto provisto y seg�n los permisos del usuario.

## Tecnolog�as Utilizadas
- **Semantic Kernel**: Para la orquestaci�n de prompts y la integraci�n con modelos de lenguaje.
- **Azure Search IA**: Para indexar y recuperar informaci�n relevante en el contexto RAG.
- **OpenAI GPT-3.5**: Modelo base para generar respuestas.
- **ASP.NET Core Web API**: Para la exposici�n de los endpoints.
- **C#**: Lenguaje usado en la implementaci�n.

## Arquitectura
El sistema se compone de los siguientes m�dulos:

- **M�dulo de Ingesta**: Indexa documentos en Azure Search para enriquecer las respuestas con informaci�n espec�fica.
- **M�dulo de Procesamiento**: Usa Semantic Kernel para manejar prompts, verificar roles y recuperar contexto.
- **M�dulo API**: Expone los endpoints para consultar al asistente IA.

## Instalaci�n y Configuraci�n
1. Clonar el repositorio.
2. Instalar las dependencias necesarias.
3. Configurar las variables de entorno para las claves de OpenAI y Azure Search.
4. Ejecutar la aplicaci�n.

## Futuras Mejoras
- Implementaci�n de control de acceso m�s granular.
- Soporte para m�ltiples fuentes de informaci�n en RAG.
- Optimizar recuperaci�n sem�ntica con embeddings personalizados.

---

Este proyecto es una base para la creaci�n de asistentes inteligentes con acceso seguro y contextualizado a la informaci�n empresarial.
