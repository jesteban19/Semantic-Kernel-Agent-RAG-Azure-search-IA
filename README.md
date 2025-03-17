# Proyecto: Asistente IA con Semantic Kernel y Azure Search

Este proyecto implementa un sistema de Recuperación Aumentada Generativa (RAG) utilizando **Semantic Kernel** y **Azure Search IA**. Se exponen dos endpoints principales:

1. **Consulta libre:** Permite realizar preguntas al modelo GPT-3.5 sin restricciones.
2. **Consulta con roles:** Solo responde preguntas dentro del contexto provisto y según los permisos del usuario.

## Tecnologías Utilizadas
- **Semantic Kernel**: Para la orquestación de prompts y la integración con modelos de lenguaje.
- **Azure Search IA**: Para indexar y recuperar información relevante en el contexto RAG.
- **OpenAI GPT-3.5**: Modelo base para generar respuestas.
- **ASP.NET Core Web API**: Para la exposición de los endpoints.
- **C#**: Lenguaje usado en la implementación.

## Arquitectura
El sistema se compone de los siguientes módulos:

- **Módulo de Ingesta**: Indexa documentos en Azure Search para enriquecer las respuestas con información específica.
- **Módulo de Procesamiento**: Usa Semantic Kernel para manejar prompts, verificar roles y recuperar contexto.
- **Módulo API**: Expone los endpoints para consultar al asistente IA.

## Instalación y Configuración
1. Clonar el repositorio.
2. Instalar las dependencias necesarias.
3. Configurar las variables de entorno para las claves de OpenAI y Azure Search.
4. Ejecutar la aplicación.

## Futuras Mejoras
- Implementación de control de acceso más granular.
- Soporte para múltiples fuentes de información en RAG.
- Optimizar recuperación semántica con embeddings personalizados.

---

Este proyecto es una base para la creación de asistentes inteligentes con acceso seguro y contextualizado a la información empresarial.
